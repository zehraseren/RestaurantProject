using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.SocialMediaDtos;

namespace SignalR.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ErrorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> NotFound404Page()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/SocialMedias");
            if (response.IsSuccessStatusCode)
            {
                var jsondData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsondData);
                return View(values);
            }
            return View();
        }
    }
}
