using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;

namespace AgentApplication.Repository.Core
{
    public interface IApiKeyRepository : IBaseRepository<ApiKey>
    {
        public ApiKey GetApiKeyFromUser(long id);
    }
}
