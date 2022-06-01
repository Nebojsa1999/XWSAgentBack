using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Model.DTO;

namespace AgentApplication.Service.Core
{
    public interface IReactionService : IBaseService<Reaction>
    {
        public Reaction AddReaction(ReactionDTO reactionDTO);
        public IEnumerable<Reaction> GetReactionsByJobId(long jobId);
    }
}
