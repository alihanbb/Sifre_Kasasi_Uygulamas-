
using AppEntity.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;

namespace AppService.Services.Abstract
{
    public interface IRegisterService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDtos register);
        Task<bool> IsValidAsync(RegisterDtos createRegister);
    }
}
