﻿using AppEntity.Dtos.LoginDto;
using AppEntity.Entities;
using AppService.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace AppService.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public LoginService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        //public async Task<SignInResult> LoginAsync(LoginDtos loginDtos)
        //{
        //    return await signInManager.PasswordSignInAsync(loginDtos.UserName, loginDtos.Password, false, false);
        //}
        public async Task<AppUser?> GetUserByUsernameAsync(string username) => await userManager.FindByNameAsync(username);


        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var result = await signInManager.CheckPasswordSignInAsync(user, password, true);
            return result.Succeeded;
        }

        public async Task SignInAsync(AppUser user)
            => await signInManager.SignInAsync(user, false);
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
