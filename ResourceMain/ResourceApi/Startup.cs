using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ResourceData.Settings;
using ResourceDomainCore.Bus;
using ResourceInfraBus;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Postgresql.PostgresqlRepository.Solid;
using ResourceData.MessageBus.CommandHandlers;
using ResourceData.MessageBus.Commands;
using ResourceData.MessageBus.EventHandlers;
using ResourceData.MessageBus.Events;

namespace ResourceApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration,
            IWebHostEnvironment _env)
        {
            Configuration = configuration;
            env = _env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var allSettings = new AllSettings();
            var jwtSettings = new JwtSettings();
            var dbSettings = new DbSettings();

            Configuration.Bind("DbSettings", dbSettings);
            Configuration.Bind("JwtSettings", jwtSettings);

            if (env.IsDevelopment())
            {
                // RabbitMQ
                services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
                {
                    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
                });
            }
            else
            {
                // CloudAMQP 
                services.AddSingleton<IEventBus, CloudAMQPBus>(sp =>
                {
                    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                    return new CloudAMQPBus(sp.GetService<IMediator>(), scopeFactory);
                });
            }


            services.AddSingleton<IResourceRepository, PgResourceRepository>(sp =>
            {
                return new PgResourceRepository(dbSettings, sp.GetService<IEventBus>());
            });


            //Domain User Subscriptions
            ///services.AddTransient<TransferEventHandler>();
            services.AddTransient<BasketSubmittedByUserEventHandler>(sp =>
            {
                return new BasketSubmittedByUserEventHandler(sp.GetService<IResourceRepository>(), sp.GetService<IEventBus>());
            });
            services.AddTransient<BasketAcceptedByOperatorEventHandler>(sp =>
            {
                return new BasketAcceptedByOperatorEventHandler(sp.GetService<IResourceRepository>(), sp.GetService<IEventBus>());
            });


            //Domain User Events
            ///services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();            
            services.AddTransient<IEventHandler<BasketSubmittedByUserEvent>, BasketSubmittedByUserEventHandler>();
            services.AddTransient<IEventHandler<BasketAcceptedByOperatorEvent>, BasketAcceptedByOperatorEventHandler>();


            //Domain User Commands
            ///services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            //services.AddTransient<IRequestHandler<TestCommand, bool>, TestCommandHandler>();
            services.AddTransient<IRequestHandler<CheckBasketByUserCommand, bool>, CheckBasketByUserCommandHandler>();
            services.AddTransient<IRequestHandler<DoubleCheckBasketByOperatorCommand, bool>, DoubleCheckBasketByOperatorCommandHandler>();

            services.AddHttpContextAccessor();

            services.AddCors();
            services.AddControllers();

            services.AddSingleton<DbSettings>(dbSettings);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Library API",
                    Description = "Library Management System",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Aykhan Alifov",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "None",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                /*  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  c.IncludeXmlComments(xmlPath);*/
            });

            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromSeconds(1),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<BasketSubmittedByUserEvent, BasketSubmittedByUserEventHandler>();
            eventBus.Subscribe<BasketAcceptedByOperatorEvent, BasketAcceptedByOperatorEventHandler>();
        }
    }
}
