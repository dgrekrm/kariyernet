using System.Threading.Tasks;
using KariyerApp.Core;
using KariyerApp.Core.Entities;
using KariyerApp.Core.Interfaces;
using KariyerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace KariyerApp.Data.Repositories
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly ApplicationDbContext _context;

        public RecruiterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> PhoneNumberExistsAsync(string phoneNumber)
        {
            return await _context.Recruiters.AnyAsync(r => r.PhoneNumber == phoneNumber);
        }

        public async Task AddRecruiterAsync(Recruiter recruiter)
        {
            await _context.Recruiters.AddAsync(recruiter);
        }

        public async Task<Recruiter> GetRecruiterAsync(int id)
        {
            return await _context.Recruiters.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
