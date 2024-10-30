namespace KariyerApp.Api.Dtos
{
    public class CreateRecruiterRequest
    {
        public string PhoneNumber { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
