using System.Threading.Tasks;
using AppEntity.Dtos.LoginDto;
using AppEntity.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppService.Services.Abstract
{
    public interface ILoginService
    {
        //Task<SignInResult> LoginAsync(LoginDtos loginDtos);
        Task Logout();
        Task<AppUser?> GetUserByUsernameAsync(string username);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task SignInAsync(AppUser user);
    }
}
