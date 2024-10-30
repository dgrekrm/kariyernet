using KariyerApp.Core.Entities;
using KariyerApp.Core;
using KariyerApp.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KariyerApp.DataAccess.Repositories
{
    public class JobAdvertisementRepository : IJobAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;

        public JobAdvertisementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JobAdvertisement> AddAsync(JobAdvertisement jobAdvertisement)
        {
            jobAdvertisement.Compensations = await _context.Compensations.Where(w => jobAdvertisement.Compensations.Select(s => s.Id).Contains(w.Id)).ToListAsync();

            await _context.JobAdvertisements.AddAsync(jobAdvertisement);

            return jobAdvertisement;
        }

        public async Task<int> CalculateJobQuality(JobAdvertisement jobAdvertisement)
        {
            var score = 0;

            if (jobAdvertisement.WorkType.HasValue)
                score++;

            if (jobAdvertisement.Salary.HasValue)
                score++;

            if (jobAdvertisement.Compensations.Any())
                score++;

            if (!jobAdvertisement.Description.Split(" ").ToList().Exists(a => ProhibitedWords.Words.Exists(pw => pw.Equals(a, StringComparison.OrdinalIgnoreCase))))
                score += 2;

            return score;
        }

        public async Task<List<Compensation>> GetCompensationsAsync(List<int> compensationIds)
        {
            return await _context.Compensations
                .Where(c => compensationIds.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<List<JobAdvertisement>> GetJobAdvertisementsByDaysAsync(int days)
        {
            var dateLimit = DateTime.UtcNow.AddDays(-days);
            return await _context.JobAdvertisements
                .Where(ad => ad.CreatedDate >= dateLimit) // Son X gün içinde olan ilanlar
                .ToListAsync();
        }
    }
}
