using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AgentApplication.Configuration;
using AgentApplication.Model;
using AgentApplication.Repository;
using AgentApplication.Service.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AgentApplication.Service
{
    public class JobService : BaseService<Job>, IJobService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public IApiKeyService apikeyService;

        public JobService(ProjectConfiguration configuration, ILogger<JobService> logger, IApiKeyService apikeyService)
        {
            _logger = logger;
            _configuration = configuration;
            this.apikeyService = apikeyService;
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

        

        public async  Task<Job> AddJob(Job entity)
        {
            if (entity == null)
            {
                return null;
            }
            Job job = new Job();
            
            ApiKey key = apikeyService.GetApiKeyFromUser(entity.Business.Owner.Id);

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                job.Description = entity.Description;
                job.Position = entity.Position;
                job.Precondition = entity.Precondition;
                job.DescriptionActivity = entity.DescriptionActivity;
                job.Business = unitOfWork.Businesses.Get(entity.Business.Id);

                string json = JsonConvert.SerializeObject(job);
                var myHttpClient = new HttpClient();
                myHttpClient.DefaultRequestHeaders.Add("X-API-KEY", key.ApiKeyString);
                var response = await myHttpClient.PostAsync("http://localhost:8080/api/jobs/integration/saveJob", new StringContent(json, Encoding.UTF8, "application/json"));

                unitOfWork.Jobs.Add(job);
                _ = unitOfWork.Complete();



                return job;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in Add {e.Message} {e.StackTrace}");
                return null;
            }

        }

        public Job AddJobWithoutPublish(Job entity)
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

                return job;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in JobService in AddJobWithoutPublish {e.Message} {e.StackTrace}");
                return null;
            }
        }

        public Job GetJob(long id)
        {
            using UnitOfWork unitOfWork = new(new ProjectContext());
            return unitOfWork.Jobs.GetJob(id);
        }

        public IEnumerable<Job> GetJobsByUserId(long id)
        {
            using UnitOfWork unitOfWork = new(new ProjectContext());
            return unitOfWork.Jobs.GetJobsByUserId(id);
        }


    }
}
