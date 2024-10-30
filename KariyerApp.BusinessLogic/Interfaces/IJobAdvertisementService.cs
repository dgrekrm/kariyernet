using KariyerApp.Core.Entities;

namespace KariyerApp.BusinessLogic.Interfaces
{
    public interface IJobAdvertisementService
    {
        Task<JobAdvertisement> CreateJobAdvertisementAsync(JobAdvertisement jobAdvertisement);
        Task<List<JobAdvertisement>> GetJobAdvertisementsByDaysAsync(int days);
    }
}
