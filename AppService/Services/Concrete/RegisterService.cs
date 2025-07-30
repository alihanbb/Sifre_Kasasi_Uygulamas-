using AppEntity.Dtos.RegisterDto;
using AppEntity.Entities;
using AppService.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AppService.Services.Concrete
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        public RegisterService(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterDtos register)
        {
            //var appuser = mapper.Map<AppUser>(register);
            AppUser appuser = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email,
                Name = register.Name,
                SurName = register.SurName
            };
            var result = await userManager.CreateAsync(appuser, register.Password);
            return result;
        }
        public async Task<bool> IsValidAsync(RegisterDtos createRegister)
        {
            //var existingUser = await userManager.FindByEmailAsync(createRegister.Email);
            //if (existingUser != null)
            //    return false;

            var existingUserName = await userManager.FindByNameAsync(createRegister.UserName);
            if (existingUserName != null)
                return false;   

            return true;
        }


    }
}
