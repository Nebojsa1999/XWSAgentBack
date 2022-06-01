using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Model.DTO;
using AgentApplication.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : BaseController<Reaction>
    {
        private IReactionService reactionService;
        public IUserService userService;

        public ReactionController(ProjectConfiguration config, IUserService userService, IReactionService reactionService) : base(config, userService)
        {
            this.reactionService = reactionService;
        }

        [Route("addReaction")]
        [HttpPost]
        public IActionResult AddReaction(ReactionDTO reactionDTO)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(reactionService.AddReaction(reactionDTO));
        }

        [Route("getReactionsByJobId/{jobId}")]
        [HttpGet]
        public IActionResult GetReactionsByJobId(long jobId)
        {    

            return Ok(reactionService.GetReactionsByJobId(jobId));
        }
    }
  
}
