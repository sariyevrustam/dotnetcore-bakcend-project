FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
#Copy csproj and restore ass distint layers
COPY *.sln .
#Volume mount for Resources
RUN mkdir volume-resources

RUN mkdir ResourceMain
COPY ResourceMain/. ./ResourceMain
RUN dotnet restore

# copy everything else and build app
WORKDIR /app/ResourceMain/ResourceApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/ResourceMain/ResourceApi/out .
ENTRYPOINT ["dotnet", "ResourceApi.dll"]

