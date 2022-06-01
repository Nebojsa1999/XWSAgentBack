using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Model.DTO;
using AgentApplication.Repository;
using AgentApplication.Service.Core;
using AgentApplication.Util;
using Microsoft.Extensions.Logging;

namespace AgentApplication.Service
{
    public class ReactionService : BaseService<Reaction>, IReactionService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public ReactionService(ProjectConfiguration configuration, ILogger<ReactionService> logger)
        {
            _logger = logger;
            _configuration = configuration;

        }

        public  Reaction AddReaction(ReactionDTO reactionDTO)
        {
            if (reactionDTO == null)
            {
                return null;
            }
            Reaction reaction = new Reaction();

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());

                reaction.Grade = ParseHelper.gradeString(reactionDTO.Grade);
                reaction.Comment = reactionDTO.Comment;
                reaction.InterviewImpression = reactionDTO.InterviewImpression;
                reaction.Wage = reactionDTO.Wage;
                reaction.User = unitOfWork.Users.Get(reactionDTO.User.Id);
                 reaction.Job = unitOfWork.Jobs.Get(reactionDTO.Job.Id);
               
                unitOfWork.Reactions.Add(reaction);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in ReactionService in Add Method {e.Message} {e.StackTrace}");
                return null;
            }

            return reaction;
        }

        public IEnumerable<Reaction> GetReactionsByJobId(long jobId)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.Reactions.GetReactionsByJobId(jobId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in ReactionService in GetReactionsByJobId Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }
    }
}
