using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Model.DTO;
using AgentApplication.Service.Core;
using AgentApplication.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AgentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController<User>
    {
        private readonly ProjectConfiguration _config;
        private readonly IUserService userService;

        public AuthController(ProjectConfiguration config, IUserService userService) : base(config, userService)
        {
            _config = config;
            _userService = userService;
        }
        [HttpGet]
        [Authorize]
        [Route("current")]
        public IActionResult GetCurrent()
        {
            return Ok(base.GetCurrentUser());
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginDTO logindto)
        {
            if (logindto.ClientID != _config.ClientID || logindto.ClientSecret != _config.ClientSecret)
            {
                return BadRequest("Client's ID or Client's secret was not accurate, please check again");
            }

            if (logindto == null || logindto.UserName == null || logindto.Password == null)
            {
                return BadRequest("Invalid client request");
            }

            User userEmail = _userService.GetUserWithUserName(logindto.UserName);

            if (userEmail == null || !userEmail.Enabled || !BCrypt.Net.BCrypt.Verify(logindto.Password, userEmail.Password))
            {
                return BadRequest("Invalid authorization!");
            }

            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config.Jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id",userEmail.Id.ToString()),
                new Claim("Email",userEmail.Email),
                new Claim("Username",userEmail.Username)
            };

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config.Jwt.Key));
            SigningCredentials signInCred = new(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new(_config.Jwt.Issuer, _config.Jwt.Audience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signInCred);
            TokenHelper token = new TokenHelper();
            token.Token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return Ok(token);
        }
    }
}
