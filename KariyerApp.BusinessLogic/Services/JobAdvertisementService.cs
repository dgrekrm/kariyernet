using KariyerApp.BusinessLogic.Interfaces;
using KariyerApp.Core;
using KariyerApp.Core.Entities;
using KariyerApp.Core.Interfaces;
using KariyerApp.DataAccess.Interfaces;

namespace KariyerApp.BusinessLogic.Services
{
    public class JobAdvertisementService : IJobAdvertisementService
    {
        private readonly IJobAdvertisementRepository _jobAdvertisementRepository;
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IElasticSearchService _elasticSearchService;

        public JobAdvertisementService(IJobAdvertisementRepository repository, IRecruiterRepository recruiterRepository, ApplicationDbContext applicationDbContext, IElasticSearchService elasticSearchService)
        {
            _jobAdvertisementRepository = repository;
            _recruiterRepository = recruiterRepository;
            _applicationDbContext = applicationDbContext;
            _elasticSearchService = elasticSearchService;
        }

        public async Task<JobAdvertisement> CreateJobAdvertisementAsync(JobAdvertisement jobAdvertisement)
        {
            var recruiter = await _recruiterRepository.GetRecruiterAsync(jobAdvertisement.RecruiterId);

            ArgumentNullException.ThrowIfNull(recruiter);

            //if (recruiter.RemainingJobPostingQuota <= 0) 
            //    throw new InvalidOperationException("kota dolu");

            //recruiter.RemainingJobPostingQuota--;

            jobAdvertisement.JobQuality = await _jobAdvertisementRepository.CalculateJobQuality(jobAdvertisement);

            var newRecord = await _jobAdvertisementRepository.AddAsync(jobAdvertisement);

            await _applicationDbContext.SaveChangesAsync();

            try
            {
                await _elasticSearchService.IndexJobAdvertisementAsync(jobAdvertisement);
            }
            catch (Exception)
            {
                //TODO: burayı doldur..
            }

            return newRecord;
        }

        public async Task<List<JobAdvertisement>> GetJobAdvertisementsByDaysAsync(int days)
        {
            try
            {
                return await _elasticSearchService.GetJobAdvertisements(days);
            }
            catch (Exception)
            {

            }
            return await _jobAdvertisementRepository.GetJobAdvertisementsByDaysAsync(days);
        }
    }
}
