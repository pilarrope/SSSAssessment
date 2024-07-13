using Microsoft.AspNetCore.Http;
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

        //Accion for the Index page: localhost+ /Clients/Clients
        public async Task<IActionResult> Clients(int page = 1)
        {
            
            int pageSize = 15;// Clients per page.
            List<Client> allClients = new List<Client>();
            int currentPage = 1;
            bool moreClients = true;

            while (moreClients)
            {
                var apiResult = await _httpClientFactory.CreateClient().GetFromJsonAsync<ApiResult>($"https://tech-exercise.vercel.app/api/user?page={currentPage}&limit={pageSize}");


                if (apiResult == null || apiResult.Results == null || apiResult.Results.Count == 0)
                {

                    moreClients = false; // Stop the loop if no more data is available.
                }
                else
                {
                    allClients.AddRange(apiResult.Results);
                    currentPage++; // Increment to reach the next page.
                    if (apiResult.Results.Count < pageSize)
                    {
                        moreClients = false; // Last page. When there is not more Clients.
                    }
                }
            }



            int totalClientCount = allClients.Count; // This will count the total of clients

            var clientsToShow = allClients.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var listPagination = new ListPagination<Client>(clientsToShow, totalClientCount, page, pageSize);

            return View("Clients", listPagination);
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
