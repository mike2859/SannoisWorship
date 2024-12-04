using AutoMapper;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Core.Entities;

namespace SannoisWorship.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ChantDTO, Chant>()
            .ForMember(dest => dest.DateCreation, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ReverseMap(); 
    }

}
