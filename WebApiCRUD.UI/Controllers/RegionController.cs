using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApiCRUD.UI.Models.Regions.DTOs;
using WebApiCRUD.UI.Models.Regions.ViewModel;

namespace WebApiCRUD.UI.Controllers
{
    public class RegionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDTO> regions = new List<RegionDTO>();
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7228/Region");
                httpResponseMessage.EnsureSuccessStatusCode();

                regions.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());
            }
            catch (Exception ex)
            {

            }
            return View(regions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7228/Region"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpRequestMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null)
            {
                return RedirectToAction("Index", "Region");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:7228/Region/{id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO request)
        {
            var client = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7228/Region/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null)
            {
                return RedirectToAction("Index", "Region");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:7228/Region/{id.ToString()}");

            if(response is not null)
            {
                return View(response);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RegionDTO request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7228/Region/{request.Id}");
                httpResponseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Region");
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:7228/Region/{id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }
            return View();
        }
    }
}
