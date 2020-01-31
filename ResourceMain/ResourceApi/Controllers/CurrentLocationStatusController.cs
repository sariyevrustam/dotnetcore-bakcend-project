using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Services.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CurrentLocationStatusController
    {
        private readonly ICurrentStatusRepository currentStatusRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public CurrentLocationStatusController(IHttpContextAccessor _httpContextAccessor,
            ICurrentStatusRepository _currentStatusRepository)
        {
            httpContextAccessor = _httpContextAccessor;
            currentStatusRepository = _currentStatusRepository;
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult GetAll()
        {
            ItemResult itemResult = currentStatusRepository.GetAll();
            return itemResult;
        }
    }
}