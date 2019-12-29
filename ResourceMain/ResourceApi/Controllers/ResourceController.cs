using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Services.Security.JWT;

namespace ResourceApi.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceRepository pgResource;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public ResourceController(IResourceRepository _pgResource,
            IHttpContextAccessor _httpContextAccessor)
        {
            pgResource = _pgResource;
            httpContextAccessor = _httpContextAccessor;
            //currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult Get()
        {
            Console.WriteLine("____________________Http Request_____________________________");
            Console.WriteLine("username : " + httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserName));
            Console.WriteLine("userId" + httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId));
            Console.WriteLine("userRole" + httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value);
            Console.WriteLine("_________________________________________________");

            ItemResult itemResult = pgResource.GetAll();
            return itemResult;
        }

        [HttpGet("{id}")]
        public ItemResult Get(int id)
        {
            ItemResult itemResult = pgResource.Get(id);
            return itemResult;
        }

        [HttpPost]
        public ItemResult Post([FromForm] InResource inResource)
        {
            var resourceFile = inResource.ResourceFile;
            var filePath = Path.Combine("C:/Users/ayxan/Desktop/testUploadFolder", resourceFile.FileName);

            if (resourceFile.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    resourceFile.CopyTo(fileStream);
                }
            }

            return pgResource.Add(inResource);
        }

        [HttpPut("{id}")]
        public ItemResult Put(int id, [FromBody] InResource inResource)
        {
            return pgResource.Edit(id, currentUserId, inResource);
        }

        [HttpDelete("{id}")]
        public ItemResult Delete(int id)
        {
            return pgResource.Delete(id, currentUserId);
        }

        [AllowAnonymous]
        [HttpPost]
        public ItemResult CheckAvailabilityForBasket([FromBody] InBasket inBasket)
        {
            Console.WriteLine(inBasket);
            return pgResource.CheckAvailabilityForBasket(inBasket);
        }
    }
}