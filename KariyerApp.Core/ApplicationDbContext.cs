using KariyerApp.Core.Entities;
using KariyerApp.Core.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace KariyerApp.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<JobAdvertisement> JobAdvertisements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new EntityInterceptor());
        }
    }
}
