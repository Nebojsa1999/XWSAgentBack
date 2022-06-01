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
                return unitOfWork.Jobs.GetAllJobs();

            }


            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in GetAllJobs Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }

        public override Job Add(Job entity)
        {
            if (entity == null)
            {
                return null;
            }
            Job job = new Job();

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                job.Description = entity.Description;
                job.Position = entity.Position;
                job.Precondition = entity.Precondition;
                job.DescriptionActivity = entity.DescriptionActivity;
                job.Business = unitOfWork.Businesses.Get(entity.Business.Id);
                
                unitOfWork.Jobs.Add(job);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in Add {e.Message} {e.StackTrace}");
                return null;
            }

            return job;
        }

        public Job GetJob(long id)
        {
            using UnitOfWork unitOfWork = new(new ProjectContext());
            return unitOfWork.Jobs.GetJob(id);
        }


    }
}
