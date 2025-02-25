using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BasketDtos;
using SignalR.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;

namespace SignalR.WebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.goToBasket = id;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Products/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto cbdto)
        {
            if (cbdto.MenuTableId == 0)
            {
                return BadRequest("MenuTableId 0 geliyor.");
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(cbdto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44354/api/Baskets", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Json(new { success = false, message = "Sepete ekleme başarısız oldu." });
            }
        }
    }
}

