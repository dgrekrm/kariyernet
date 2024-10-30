using KariyerApp.Core.Entities;

namespace KariyerApp.BusinessLogic.Interfaces
{
    public interface IElasticSearchService
    {
        Task<List<JobAdvertisement>> GetJobAdvertisements(int days);
        Task IndexJobAdvertisementAsync(JobAdvertisement jobAdvertisement);
    }
}
