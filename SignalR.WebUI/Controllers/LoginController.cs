﻿using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using SignalR.WebUI.Dtos.IdentityDtos;

namespace SignalR.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto ldto)
        {
            var result = await _signInManager.PasswordSignInAsync(ldto.UserName, ldto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Statistic");
            }
            return View();
        }
    }
}
