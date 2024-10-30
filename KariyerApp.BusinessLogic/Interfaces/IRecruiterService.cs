using System.Threading.Tasks;
using KariyerApp.Core.Entities;

namespace KariyerApp.BusinessLogic.Interfaces
{
    public interface IRecruiterService
    {
        Task<Recruiter> RegisterRecruiterAsync(Recruiter recruiter);
    }
}
