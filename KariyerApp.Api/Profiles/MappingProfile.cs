using AutoMapper;
using KariyerApp.Api.Dtos;
using KariyerApp.Core.Entities;

namespace KariyerApp.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRecruiterRequest, Recruiter>()
                .ForMember(dest => dest.RemainingJobPostingQuota, opt => opt.MapFrom(src => 2)); // Varsayılan değer

            CreateMap<CreateJobAdvertisementRequest, JobAdvertisement>()
                .ForMember(dest => dest.Compensations, opt => opt.MapFrom(src => src.CompensationIds.Select(id => new Compensation { Id = id }).ToList()))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => DateTime.Now.AddDays(15)));
        }
    }
}
