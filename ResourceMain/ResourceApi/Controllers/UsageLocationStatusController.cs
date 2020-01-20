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
    public class UsageLocationStatusController : ControllerBase
    {
        private readonly IUsageLocationStatusRepository usageLocationStatusRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public UsageLocationStatusController(IHttpContextAccessor _httpContextAccessor,
            IUsageLocationStatusRepository _usageLocationStatusRepository)
        {
            httpContextAccessor = _httpContextAccessor;
            usageLocationStatusRepository = _usageLocationStatusRepository;
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult GetAll()
        {
            ItemResult itemResult = usageLocationStatusRepository.GetAll();
            return itemResult;
        }
    }
}
