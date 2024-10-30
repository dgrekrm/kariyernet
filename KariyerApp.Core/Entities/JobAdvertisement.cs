using KariyerApp.Core.Enums;
using KariyerApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KariyerApp.Core.Entities
{
    public class JobAdvertisement : IIdEntity, ICreatableEntity, IUpdateableEntity, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public DateTime ExpirationDate { get; set; }

        public int? JobQuality { get; set; }

        public ICollection<Compensation> Compensations { get; set; } = new List<Compensation>();

        public WorkType? WorkType { get; set; }

        public decimal? Salary { get; set; }

        // İlişki: İşveren (Recruiter)
        public int RecruiterId { get; set; }
        [ForeignKey(nameof(RecruiterId))]
        public Recruiter Recruiter { get; set; } = default!;

        // ICreatableEntity properties
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = default!;

        // IUpdateableEntity properties
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; } = default!;

        // IDeletableEntity property
        public bool IsDeleted { get; set; }
    }
}
