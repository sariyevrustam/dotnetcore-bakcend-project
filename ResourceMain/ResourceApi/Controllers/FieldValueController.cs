﻿using System;
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
    public class FieldValueController : ControllerBase
    {
        private readonly IFieldValuesRepository fieldValuesRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;

        public FieldValueController(IHttpContextAccessor _httpContextAccessor,
            IFieldValuesRepository _fieldValuesRepository)
        {
            httpContextAccessor = _httpContextAccessor;
            fieldValuesRepository = _fieldValuesRepository;
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(CustomClaims.UserId).Value);
        }

        [HttpGet]
        public ItemResult PublishingHouseGetAll()
        {
            ItemResult itemResult = fieldValuesRepository.PublishingHouseGetAll();
            return itemResult;
        }
    }
}
