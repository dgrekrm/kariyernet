using KariyerApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KariyerApp.Core.Entities
{
    public class Recruiter : IIdEntity, ICreatableEntity, IUpdateableEntity, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; } = default!;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = default!;

        [Required]
        public int RemainingJobPostingQuota { get; set; }

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
