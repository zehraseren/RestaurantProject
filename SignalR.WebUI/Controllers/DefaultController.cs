﻿using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
    }
}
