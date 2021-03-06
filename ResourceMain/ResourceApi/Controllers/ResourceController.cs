﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs;
using ResourceData.Postgresql.Models.Inputs.ReturnedResource;
using ResourceData.Postgresql.Models.Inputs.ReturningBookshelfResources;
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
        private readonly IResourceTypeRepository resourceTypeRepository;
        private readonly IElectronResourceTypeRepository electronResourceTypeRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public ResourceController(IResourceRepository _pgResource,
            IResourceTypeRepository _resourceTypeRepository,
            IElectronResourceTypeRepository _electronResourceTypeRepository,
            IHttpContextAccessor _httpContextAccessor)
        {
            pgResource = _pgResource;
            resourceTypeRepository = _resourceTypeRepository;
            electronResourceTypeRepository = _electronResourceTypeRepository;
            httpContextAccessor = _httpContextAccessor;

            if (httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId) != null)
            {
                currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
            }            
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
            var filePath = Path.Combine("/app/volume-resources", resourceFile.FileName);

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

        [HttpGet("{categoryId}")]
        public ItemResult GetByCategory(int categoryId)
        {
            ItemResult itemResult = pgResource.GetByCategory(categoryId);
            return itemResult;
        }

        [HttpGet("{categoryId}")]
        public ItemResult GetAllByCategory(int categoryId)
        {
            ItemResult itemResult = pgResource.GetAllByCategory(categoryId);
            return itemResult;
        }

        [HttpPost]
        public ItemResult SearchResourceAuthor([FromBody] InResourceAuthorSearchFilter inResourceAuthorSearchFilter)
        {
            return pgResource.ResourceAuthorSearch(inResourceAuthorSearchFilter);
        }

        [HttpPost]
        public ItemResult ResourceSearchForSearchButton([FromBody] InResourceAuthorSearchFilter inResourceAuthorSearchFilter)
        {
            Console.WriteLine("-------------ResourceSearchForSearchButton----------------");
            Console.WriteLine(JsonConvert.SerializeObject(inResourceAuthorSearchFilter));
            Console.WriteLine("-----------------------------");
            return pgResource.ResourceSearchForSearchButton(inResourceAuthorSearchFilter);
        }

        [HttpGet]
        public ItemResult GetAllResourceType()
        {
            return resourceTypeRepository.GetAll();
        }

        [HttpGet]
        public ItemResult GetAllElectronResourceType()
        {
            return electronResourceTypeRepository.GetAll();
        }

        [HttpPost]
        public ItemResult GetAvailableCopyIds([FromBody] InReturningBookshelfResourceCollection inReturningBookshelfResourceCollection)
        {
            return pgResource.GetAvailableCopyIds(inReturningBookshelfResourceCollection);
        }

        [HttpGet]
        public ItemResult GetMinimalPublishYear()
        {
            return pgResource.GetMinimalPublishYear();
        }

        [HttpPost]
        public ItemResult AddingNewElectronResource([FromForm] UploadedElectronResource uploadedElectronResource)
        {
            if (uploadedElectronResource.ResourcePdf.Length > 0)
            {                
                var filePath = Path.Combine("/app/volume-resources", uploadedElectronResource.ResourcePdf.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadedElectronResource.ResourcePdf.CopyTo(fileStream);
                }
            }

            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        public ItemResult GetAllResourcesByIds([FromBody] List<int> requiredResourceIds)
        {          
            return pgResource.GetAllResourcesByIds(requiredResourceIds);
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetPdfTest()
        {
            var stream = new FileStream(@"/app/volume-resources", FileMode.Open);
            return File(stream, "application/pdf", "AyxanƏlifov.docx");
        }

    }
}