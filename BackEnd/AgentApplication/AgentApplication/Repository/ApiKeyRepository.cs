using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;

namespace AgentApplication.Repository
{
    public class ApiKeyRepository: BaseRepository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(ProjectContext context) : base(context)
        {

        }
    }
}
