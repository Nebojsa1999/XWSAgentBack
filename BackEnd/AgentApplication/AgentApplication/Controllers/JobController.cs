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

            return Ok(jobService.AddJob(job));
        }

        [Route("addJobWithoutPublish")]
        [HttpPost]
        public IActionResult AddJobWithoutPublish(Job job)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(jobService.AddJobWithoutPublish(job));
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
        [Route("getJob/{id}")]
        [HttpGet]
        public IActionResult GetJob(long id)
        {
            return Ok(jobService.GetJob(id));
        }

        [Route("getJobsByUserId/{id}")]
        [HttpGet]
        public IActionResult GetJobsByUserId(long id)
        {
            return Ok(jobService.GetJobsByUserId(id));
        }
    }
}
