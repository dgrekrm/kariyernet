using System.Threading.Tasks;
using KariyerApp.Core.Entities;

namespace KariyerApp.Core.Interfaces
{
    public interface IRecruiterRepository
    {
        Task<bool> PhoneNumberExistsAsync(string phoneNumber);
        Task AddRecruiterAsync(Recruiter recruiter);
        Task<Recruiter> GetRecruiterAsync(int id);
    }
}
