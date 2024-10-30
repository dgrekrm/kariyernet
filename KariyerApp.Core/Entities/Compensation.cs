using KariyerApp.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace KariyerApp.Core.Entities
{
    public class Compensation : IIdEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        public ICollection<JobAdvertisement> JobAdvertisements { get; set; } = new List<JobAdvertisement>();

    }
}
