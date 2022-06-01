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
    public class UserController : BaseController<User>
    {
        private IUserService userService;

        public UserController(ProjectConfiguration config, IUserService userService) : base(config, userService)
        {
            this.userService = userService;

        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(RegisterDTO user)
        {
            if (userService.GetUserWithUserName(user.Username) != null)
            {
                return BadRequest("UserName already exists");
            }

            return Ok(userService.AddUser(user));
        }
    }
}
