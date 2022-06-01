using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Service.Core;
using Microsoft.Extensions.Logging;

namespace AgentApplication.Service
{
    public class ApiKeyService : BaseService<ApiKey>, IApiKeyService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public IUserService userService;

        public ApiKeyService(ProjectConfiguration configuration, ILogger<ApiKeyService> logger, IUserService userservice)
        {
            _logger = logger;
            _configuration = configuration;
            this.userService = userservice;

        }
    }
}
