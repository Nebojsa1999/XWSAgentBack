using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;

namespace AgentApplication.Service.Core
{
    public interface IJobService : IBaseService<Job>
    {
        public IEnumerable<Job> GetAllJobs();
    }
}
