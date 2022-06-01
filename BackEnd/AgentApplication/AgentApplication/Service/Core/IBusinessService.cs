using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;

namespace AgentApplication.Service.Core
{
    public interface IBusinessService : IBaseService<Business>
    {
        public IEnumerable<Business> GetUnactivatedBusinesses();
        public Business AddBusiness(Business entity);
        public bool ActivateBusiness(long businessId);
        public Business GetBusinessByUser(long userId);
        public IEnumerable<Business> GetAllBusinesses();
    }
}
