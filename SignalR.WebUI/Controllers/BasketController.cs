using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44354/api/Baskets/BasketListByMenuTableWithProductName?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            id = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44354/api/Basket/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
