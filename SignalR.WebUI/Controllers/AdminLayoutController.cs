using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
