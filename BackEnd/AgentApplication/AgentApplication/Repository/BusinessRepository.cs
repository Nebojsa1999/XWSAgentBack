using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Model;
using AgentApplication.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace AgentApplication.Repository
{
    public class BusinessRepository: BaseRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(ProjectContext context) : base(context)
        {

        }

        public IEnumerable<Business> GetUnactivatedBusinesses()
        {
            List<Business> businesses = new List<Business>();
            foreach(Entity entity in ProjectContext.Businesses)
            {
                if(((Business)entity).Activated == false)
                {
                    businesses.Add((Business)entity);
                }
            }

            return businesses;
        }

        public Business GetBusinessByUser(long userId)
        {
            return ProjectContext.Businesses.Where(x => x.Owner.Id == userId).FirstOrDefault();
        }

        public Business GetBusiness(long id)
        {
            return ProjectContext.Businesses.Where(x => x.Id == id).Include(x => x.Owner).FirstOrDefault();
        }

    }
}
