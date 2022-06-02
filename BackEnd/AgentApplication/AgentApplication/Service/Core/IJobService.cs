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
        public Job GetJob(long id);
        public  Task<Job> AddJob(Job entity);
        public Job AddJobWithoutPublish(Job entity);
        public IEnumerable<Job> GetJobsByUserId(long id);
    }
}
