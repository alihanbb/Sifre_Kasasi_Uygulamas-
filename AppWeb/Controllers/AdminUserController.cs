using AppEntity.Dtos.UserDto;
using AppService.Services.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    
    public class AdminUserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public AdminUserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUserAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAdmin([FromBody] CreateUserDto createUser)
        {
            if (ModelState.IsValid)
            {
                await userService.CreateAsync(createUser);
               // return RedirectToAction(nameof(Index));
               return Json(new { success = true, message = "User created successfully" });
            }
            //return View(createUser);
            return Json(new { success = false, message = "Invalid data" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserAdmin(Guid id)
        {
            var user = await userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UpdateUserDto>(user);
            return View(userDto); 
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAdmin([FromBody]UpdateUserDto updateUser)
        {
            if (ModelState.IsValid)
            {
                await userService.UpdatesAsync(updateUser);
                //return RedirectToAction(nameof(Index));
                return Json(new { success = true, message = "User updated successfully" });
            }
            //return View(updateUser);
            return Json(new { success = false, message = "Invalid data" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserAdmin([FromBody]Guid id)
        {   
            await userService.DeleteAsync(id);
            //return RedirectToAction(nameof(Index));
           return Json(new { success = true, message = "User deleted successfully" });
        }
    }

}

