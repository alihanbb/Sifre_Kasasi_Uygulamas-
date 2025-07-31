using AppEntity.Dtos.RegisterDto;
using AppService.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IRegisterService registerService;
        private readonly ILogger<RegisterController> logger;
  

        public RegisterController(IRegisterService registerService, ILogger<RegisterController> logger)
        {
            this.registerService = registerService;
            this.logger = logger;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDtos register)
        {
            if (!await registerService.IsValidAsync(register))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya e-posta zaten kayıtlı.");
                return View(register);
            }

            var result = await registerService.CreateUserAsync(register);

            if (result.Succeeded)
            {
                logger.LogInformation("Kullanıcı başarıyla kaydedildi: {UserName}", register.UserName);
                return RedirectToAction("Index", "Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(register);
        }



    }
}
