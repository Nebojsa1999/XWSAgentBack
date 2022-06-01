using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace AgentApplication.Repository
{
    public class JobRepository: BaseRepository<Job>, IJobRepository
    {
        public JobRepository(ProjectContext context) : base(context)
        {

        }
        public IEnumerable<Job> GetAllJobs()
        {
            return ProjectContext.Jobs.Include(x=> x.Business).Include(x=>x.Business.Owner).ToList();
        }
        public Job GetJob(long id)
        {
            return ProjectContext.Jobs.Where(x => x.Id == id).Include(x => x.Business).Include(x => x.Business.Owner).FirstOrDefault();
        }

    }
}
