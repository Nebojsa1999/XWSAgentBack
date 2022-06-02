using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgentApplication.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : BaseController<ApiKey>
    {
        private IApiKeyService apiKeyService;

        public ApiKeyController(ProjectConfiguration config, IApiKeyService apiKeyService, IUserService userService) : base(config,userService)
        {
            this.apiKeyService = apiKeyService;
        }

        [Route("saveApiKey")]
        [HttpPost]
        public IActionResult SaveApiKey(ApiKey apiKey)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }
            return Ok(apiKeyService.Add(apiKey));

        }

        [Route("getApiKeyByUserId/{id}")]
        [HttpGet]
        public IActionResult GetApiKeyByUserId(long id)
        {
            return Ok(apiKeyService.GetApiKeyFromUser(id));
        }
    }
}
