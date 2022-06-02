using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;

namespace AgentApplication.Repository.Core
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        public IEnumerable<Job> GetAllJobs();
        public Job GetJob(long id);
        public IEnumerable<Job> GetJobsByUserId(long id);


    }
}
