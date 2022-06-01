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
    public class JobService : BaseService<Job>, IJobService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public JobService(ProjectConfiguration configuration, ILogger<JobService> logger)
        {
            _logger = logger;
            _configuration = configuration;

        }

        public IEnumerable<Job> GetAllJobs()
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                IEnumerable<Job> enteites = unitOfWork.Jobs.GetAll();

                return enteites;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in GetAllJobs Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }

        
    }
}
