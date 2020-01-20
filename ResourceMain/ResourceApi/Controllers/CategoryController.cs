using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Services.Security.JWT;

namespace ResourceApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public CategoryController(IHttpContextAccessor _httpContextAccessor,
            ICategoryRepository _categoryRepository)
        {
            httpContextAccessor = _httpContextAccessor;
            categoryRepository = _categoryRepository;
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult GetAll()
        {
            ItemResult itemResult = categoryRepository.GetAll();
            return itemResult;
        }       
    }
}

