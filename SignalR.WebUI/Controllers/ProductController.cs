using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SignalR.CommonLayer.Enums;
using SignalR.CommonLayer.Helpers;
using SignalR.WebUI.Dtos.ProductDtos;
using SignalR.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SignalR.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Products/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsondData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Categories");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> category = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            ViewBag.StatusList = Enum.GetValues(typeof(StockStatus))
              .Cast<StockStatus>()
              .Select(s => new SelectListItem
              {
                  Text = StockStatusExtentions.GetStockStatusString(s),
                  Value = ((int)s).ToString()
              });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto cpdto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(cpdto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44354/api/Products", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44354/api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseC = await client.GetAsync("https://localhost:44354/api/Categories");
            var jsonDataC = await responseC.Content.ReadAsStringAsync();
            var valuesC = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataC);
            List<SelectListItem> category = (from x in valuesC
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            var responseP = await client.GetAsync($"https://localhost:44354/api/Products/{id}");
            if (responseP.IsSuccessStatusCode)
            {
                var jsonDataP = await responseP.Content.ReadAsStringAsync();
                var valuesP = JsonConvert.DeserializeObject<UpdateProductDto>(jsonDataP);

                ViewBag.StatusList = Enum.GetValues(typeof(StockStatus))
                    .Cast<StockStatus>()
                    .Select(s => new SelectListItem
                    {
                        Text = StockStatusExtentions.GetStockStatusString(s),
                        Value = ((int)s).ToString()
                    });

                return View(valuesP);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:44354/api/Products", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
