using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController<Job>
    {
        private IJobService jobService;
        public IUserService userService;

        public JobController(ProjectConfiguration config, IUserService userService, IJobService jobService) : base(config, userService)
        {
            this.jobService = jobService;
        }

        [Route("addJob")]
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(jobService.Add(job));
        }

        [Route("getAllJobs")]
        [HttpGet]
        public IActionResult GetAllJobs()
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }
            return Ok(jobService.GetAllJobs());
        }
    }
}
