using KariyerApp.Core.Enums;

namespace KariyerApp.Api.Dtos
{
    public class CreateJobAdvertisementRequest
    {
        public int JobTitleId { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<int> CompensationIds { get; set; } = [];
        public WorkType WorkType { get; set; }
        public decimal? Salary { get; set; }
        public int RecruiterId { get; set; }
    }
}
