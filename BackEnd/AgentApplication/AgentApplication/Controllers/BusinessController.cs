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
    public class BusinessController : BaseController<Business>
    {
        private IBusinessService businesService;
        public IUserService userService;

        public BusinessController(ProjectConfiguration config, IUserService userService, IBusinessService businesService) : base(config, userService)
        {
            this.businesService = businesService;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateBusiness(Business business)
        {
            return Ok(businesService.AddBusiness(business));
        }
        

        [Route("getUnactivated")]
        [HttpGet]
        public IActionResult GetUnactivatedBusinesses()
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }

            return Ok(businesService.GetUnactivatedBusinesses());

        }

        [Route("activateBusiness/{businessId}")]
        [HttpPut]
        public IActionResult ActivateBusiness(long businessId)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }
            return Ok(businesService.ActivateBusiness(businessId));

        }

        [Route("getBusinessByUser")]
        [HttpGet]
        public IActionResult GetBusinessByUser()
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }
            return Ok(businesService.GetBusinessByUser(userCurrent.Id));
        }

        [Route("updateCompany")]
        [HttpPut]

        public IActionResult UpdateCompany(Business business)
        {
            User userCurrent = GetCurrentUser();
            if (userCurrent == null)
            {
                return BadRequest("Must be logged in");

            }
            return Ok(businesService.Update(business.Id,business));

        }

  

    }
}
