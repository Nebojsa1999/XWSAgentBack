using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Model.DTO;

namespace AgentApplication.Service.Core
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserWithUserName(string userName);
        User AddUser(RegisterDTO entity);

    }
}
