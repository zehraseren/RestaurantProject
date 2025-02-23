using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BookingDtos;
using SignalR.WebUI.Models;

namespace SignalR.WebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Contacts");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto cbdto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseC = await client.GetAsync("https://localhost:44354/api/Contacts");
            responseC.EnsureSuccessStatusCode();
            string responseBody = await responseC.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;

            cbdto.Description = "Deneme";

            var jsonData = JsonConvert.SerializeObject(cbdto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseB = await client.PostAsync("https://localhost:44354/api/Bookings", content);
            if (responseB.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                //var errorResponse = await responseB.Content.ReadAsStringAsync();
                //ModelState.AddModelError(string.Empty, errorResponse);
                //return View();

                var errorResponse = await responseB.Content.ReadFromJsonAsync<ApiValidationErrorResponse>();
                if (errorResponse?.Errors != null)
                {
                    foreach (var error in errorResponse.Errors)
                    {
                        foreach (var errorMessage in error.Value)
                        {
                            ModelState.AddModelError(error.Key, errorMessage);
                        }
                    }
                }
                return View(cbdto);
            }
        }
    }
}
