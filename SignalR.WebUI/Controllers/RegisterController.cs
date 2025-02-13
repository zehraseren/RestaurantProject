using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using SignalR.WebUI.Dtos.IdentityDtos;
using Microsoft.AspNetCore.Authorization;

namespace SignalR.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto rdto)
        {
            var appUser = new AppUser()
            {
                Name = rdto.Name,
                Surname = rdto.Surname,
                UserName = rdto.UserName,
                Email = rdto.Mail,
            };

            var result = await _userManager.CreateAsync(appUser, rdto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
