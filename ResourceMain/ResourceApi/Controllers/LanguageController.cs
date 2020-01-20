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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository languageRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public LanguageController(IHttpContextAccessor _httpContextAccessor,
            ILanguageRepository _languageRepository)
        {
            httpContextAccessor = _httpContextAccessor;
            languageRepository = _languageRepository;
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult GetAll()
        {
            ItemResult itemResult = languageRepository.GetAll();
            return itemResult;
        }
    }
}
