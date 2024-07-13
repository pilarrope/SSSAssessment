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

        //Accion for the Index page: localhost+ /Clients
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var apiResult = await client.GetFromJsonAsync<ApiResult>("https://tech-exercise.vercel.app/api/user");
            return View(apiResult.Results);
        }

        //Acction for the Details page: localhost + Clients/Details/ + User  User example: b862e179-c346-4a2a-a913-75ef09d240e5
        public async Task<IActionResult> Details(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var apiResult = await client.GetFromJsonAsync<Client>($"https://tech-exercise.vercel.app/api/user/{id}");
            if (apiResult == null)
            {
                return NotFound();
            }
            return View(apiResult);
        }
    }
}
