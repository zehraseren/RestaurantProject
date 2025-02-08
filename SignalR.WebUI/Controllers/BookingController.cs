using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SignalR.WebUI.Dtos.BookingDtos;

namespace SignalR.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Bookings");
            if (response.IsSuccessStatusCode)
            {
                var jsondData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsondData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto cbdto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(cbdto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44354/api/Bookings", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44354/api/Bookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44354/api/Bookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto ubdto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(ubdto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:44354/api/Bookings", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:44354/api/Bookings/BookingStatusApproved/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:44354/api/Bookings/BookingStatusCancelled/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BookingStatusApprovedCount()
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:44354/api/Bookings/BookingStatusApprovedCount");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetBookingStatusApproved(ResultBookingStatusApprovedDto rbsadto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Bookings/GetBookingStatusAprroved");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingStatusApprovedDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetBookingStatusReceived(ResultBookingStatusApprovedDto rbsadto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Bookings/GetBookingStatusReceived");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingStatusApprovedDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetBookingStatusCancelled(ResultBookingStatusApprovedDto rbsadto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44354/api/Bookings/GetBookingStatusCancelled");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingStatusApprovedDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
