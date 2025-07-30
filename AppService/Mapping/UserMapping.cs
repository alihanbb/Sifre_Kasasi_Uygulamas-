using AppEntity.Dtos.UserDto;
using AppEntity.Entities;
using AutoMapper;

namespace AppService.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<ResultUserDto, User>().ReverseMap();
        }
    }

    
}
