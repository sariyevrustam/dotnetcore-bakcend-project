using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs;
using ResourceData.Postgresql.Models.Inputs.ReturnedResource;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Services.Security.JWT;

namespace ResourceApi.Controllers
{
    [Authorize]
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
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult Get()
        {
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

        [HttpPost]
        public ItemResult CheckResourceByInvantarId([FromBody] BasketInventors inventarIds)
        {     
            return pgResource.CheckBasketResourcesByInventorNumbers(inventarIds);
        }

        [HttpPost]
        public ItemResult GetResourceByInvantarId([FromBody] ReturnedResources returnedResource)
        {
            return pgResource.GetByInventarNumbers(returnedResource);
        }
    }
}