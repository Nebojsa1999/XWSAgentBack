using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace AgentApplication.Repository
{
    public class ReactionRepository : BaseRepository<Reaction>, IReactionRepository
    {
        public ReactionRepository(ProjectContext context) : base(context)
        {

        }

        public IEnumerable<Reaction> GetReactionsByJobId(long jobId)
        {
            return ProjectContext.Reactions.Where(x=>x.Job.Id == jobId).Include(x=> x.Job).Include(x=> x.User).ToList();
        }
    }
}
