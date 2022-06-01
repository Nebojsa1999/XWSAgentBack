using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace AgentApplication.Repository
{
    public class ApiKeyRepository: BaseRepository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(ProjectContext context) : base(context)
        {

        }

        public ApiKey GetApiKeyFromUser(long id)
        {
            return ProjectContext.ApiKeys.Where(x => x.Owner.Id == id).Include(x => x.Owner).FirstOrDefault();
        }
    }
}
