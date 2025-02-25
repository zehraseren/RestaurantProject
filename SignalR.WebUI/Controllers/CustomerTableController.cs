using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.MenuTableDtos;

namespace SignalR.WebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CustomerTableList()
        {
            var client = _httpClientFactory.CreateClient("");
            var response = await client.GetAsync("https://localhost:44354/api/MenuTables");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
