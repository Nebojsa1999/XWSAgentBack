using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;

namespace AgentApplication.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {

        }

        public User GetUserWithUserName(string userName)
        {
            return ProjectContext.Users.Where(x => x.Username == userName).FirstOrDefault();
        }

    }
}
