using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Repository;
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

        public override ApiKey Add(ApiKey entity)
        {
            if (entity == null)
            {
                return null;
            }
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                ApiKey apiKey = GetApiKeyFromUser(entity.Owner.Id);

                if (apiKey == null)
                {
                    apiKey = new ApiKey();
                    apiKey.ApiKeyString = entity.ApiKeyString;
                    apiKey.Owner = unitOfWork.Users.Get(entity.Owner.Id);
                    unitOfWork.ApiKeys.Add(apiKey);
                    _ = unitOfWork.Complete();

                }

                else
                {
                    apiKey.ApiKeyString = entity.ApiKeyString;
                    unitOfWork.ApiKeys.Update(apiKey);
                    _ = unitOfWork.Complete();
                }
                return apiKey;

            }



            catch (Exception e)
            {
                _logger.LogError($"Error in ApiKeyService in Add {e.Message} {e.StackTrace}");
                return null;
            }
           

            

        }

        public ApiKey GetApiKeyFromUser(long id)
        {

            using UnitOfWork unitOfWork = new(new ProjectContext());
            return unitOfWork.ApiKeys.GetApiKeyFromUser(id);
        }
    }
}
