using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;

namespace AgentApplication.Repository
{
    public class JobRepository: BaseRepository<Job>, IJobRepository
    {
        public JobRepository(ProjectContext context) : base(context)
        {

        }
    }
}
