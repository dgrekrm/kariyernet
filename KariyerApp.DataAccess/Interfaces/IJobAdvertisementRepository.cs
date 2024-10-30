using KariyerApp.Core.Entities;

namespace KariyerApp.DataAccess.Interfaces
{
    public interface IJobAdvertisementRepository
    {
        Task<JobAdvertisement> AddAsync(JobAdvertisement jobAdvertisement);
        Task<List<Compensation>> GetCompensationsAsync(List<int> compensationIds);
        Task<int> CalculateJobQuality(JobAdvertisement jobAdvertisement);
        Task<List<JobAdvertisement>> GetJobAdvertisementsByDaysAsync(int days);

    }
}
