using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Repository;
using AgentApplication.Service.Core;
using Microsoft.Extensions.Logging;

namespace AgentApplication.Service
{
    public class BusinessService : BaseService<Business>, IBusinessService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public IUserService userService;

        public BusinessService(ProjectConfiguration configuration, ILogger<BusinessService> logger, IUserService userservice)
        {
            _logger = logger;
            _configuration = configuration;
            this.userService = userservice;

        }

        public IEnumerable<Business> GetUnactivatedBusinesses()
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.Businesses.GetUnactivatedBusinesses();
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BusinessService in GetUnactivatedBusinesses {e.Message } in { e.StackTrace}");
                return null;
            }
        }

        public Business GetBusinessByUser(long userId)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.Businesses.GetBusinessByUser(userId);
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BusinessService in GetBusinessByUser {e.Message } in { e.StackTrace}");
                return null;
            }
        }

        public Business AddBusiness(Business entity)
        {
            if (entity == null)
            {
                return null;
            }
            Business business = new Business();

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                business.Name = entity.Name;
                business.Contact =entity.Contact;
                business.JobCulture = entity.JobCulture;
                business.JobDescription = entity.JobDescription;
                business.Owner = unitOfWork.Users.Get(entity.Owner.Id);
                business.Activated = false;

                unitOfWork.Businesses.Add(business);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BusinessService in AddBusiness {e.Message} {e.StackTrace}");
                return null;
            }

            return business;
        }

        public bool ActivateBusiness(long businessId)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                Business business = new Business();
                business = unitOfWork.Businesses.GetBusiness(businessId);
                business.Activated = true;
                business.Owner.Role = Model.Enum.Role.BusinessOwner;
                unitOfWork.Businesses.Update(business);
                _ = unitOfWork.Complete();
                return true;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BusinessService in ActivateBusiness Method {e.Message} in {e.StackTrace}");
                return false;
            }
        }

        public  IEnumerable<Business> GetAllBusinesses()
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                IEnumerable<Business> enteites = unitOfWork.Businesses.GetAll();

                return enteites;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BusinessService in GetAllBusinesses Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }
    }
}
