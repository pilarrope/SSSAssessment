using Microsoft.AspNetCore.Mvc;
using SSSAssessment.Models;

namespace SSSAssessment.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<ApiResponse>("https://tech-exercise.vercel.app/api/user");
            return View(response.Results);
        }

        public async Task<IActionResult> Details(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<Client>($"https://tech-exercise.vercel.app/api/user/{id}");
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }
    }
}
