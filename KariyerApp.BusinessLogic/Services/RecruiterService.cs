using KariyerApp.BusinessLogic.Interfaces;
using KariyerApp.Core;
using KariyerApp.Core.Entities;
using KariyerApp.Core.Interfaces;
using KariyerApp.Data.Repositories;

namespace KariyerApp.BusinessLogic
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public RecruiterService(IRecruiterRepository recruiterRepository, ApplicationDbContext applicationDbContext)
        {
            _recruiterRepository = recruiterRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Recruiter> RegisterRecruiterAsync(Recruiter recruiter)
        {
            // Telefon numarasının benzersiz olup olmadığını kontrol et
            bool phoneExists = await _recruiterRepository.PhoneNumberExistsAsync(recruiter.PhoneNumber);

            if (phoneExists)
                throw new InvalidOperationException("Bu telefon numarası zaten kullanılıyor.");

            await _recruiterRepository.AddRecruiterAsync(recruiter);

            await _applicationDbContext.SaveChangesAsync();

            return recruiter;
        }
    }
}
