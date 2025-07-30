using AppEntity.Dtos.RegisterDto;
using AppEntity.Entities;
using AutoMapper;

namespace AppService.Mapping
{
    public class RegisterMapping : Profile
    {
        public RegisterMapping()
        {
            CreateMap<RegisterDtos, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName));
            
        }
    }
}
