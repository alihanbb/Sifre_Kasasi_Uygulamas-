using AppEntity.Dtos.LoginDto;
using AppService.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDtos loginDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //var result = await loginService.LoginAsync(loginDtos);
            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index", "AdminUser");
            //}
            //var error = new IdentityError { Description = "Kullanıcı adı veya şifre hatalı" };
            //ModelState.AddModelError(string.Empty, error.Description);
            //return View();
            if (!ModelState.IsValid) return View();

            var user = await loginService.GetUserByUsernameAsync(loginDto.UserName);


            if (user == null || !await loginService.CheckPasswordAsync(user, loginDto.Password))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            await loginService.SignInAsync(user);

            return RedirectToAction("Index", "AdminUser");
            
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await loginService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
