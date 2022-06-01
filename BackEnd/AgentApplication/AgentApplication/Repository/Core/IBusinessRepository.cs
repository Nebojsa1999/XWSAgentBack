using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;

namespace AgentApplication.Repository.Core
{
    public interface IBusinessRepository  : IBaseRepository<Business>
    {
        public IEnumerable<Business> GetUnactivatedBusinesses();
        public Business GetBusinessByUser(long userId);
        public Business GetBusiness(long id);
    }
}
