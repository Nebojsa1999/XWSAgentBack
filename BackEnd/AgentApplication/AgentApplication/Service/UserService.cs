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
    public class UserService : BaseService<User>, IUserService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public UserService(ProjectConfiguration configuration, ILogger<UserService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public User AddUser(RegisterDTO entity)
        {
            if (entity == null)
            {
                return null;
            }
            User user = new User();

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                user.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

                user.Enabled = true;
                user.Gender = ParseHelper.genderString(entity.Gender);
                user.Email = entity.Email;
                user.Username = entity.Username;
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.PhoneNumber = entity.PhoneNumber;
                user.Role = Model.Enum.Role.User;
                user.DateOfBirth = DateTime.Parse(entity.DateOfBirth);
                unitOfWork.Users.Add(user);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in AddUserMethod {e.Message} {e.StackTrace}");
                return null;
            }

            return user;
        }



        public User GetUserWithUserName(string userName)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.Users.GetUserWithUserName(userName);
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in GetUserWithEmailMethod {e.Message } in { e.StackTrace}");
                return null;
            }
        }
    }
       
    }
