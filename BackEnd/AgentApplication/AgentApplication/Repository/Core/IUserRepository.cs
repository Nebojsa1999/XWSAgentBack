using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;

namespace AgentApplication.Repository.Core
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithUserName(string userName);


    }
}
