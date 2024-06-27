using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;
using System.Net.Http;

namespace Q2.Pages.Home
{
    public class ListOfMoviesModel : PageModel
    {

        public List<Studio> listStudios = new List<Studio>();
        public async Task OnGetAsync(int? id)
        {
        
            HttpClient _httpClient = new HttpClient();
            var apiUrlStudio = "http://localhost:5000/api/Studio/List";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrlStudio);
            if (response.IsSuccessStatusCode)
            {
                listStudios = await response.Content.ReadFromJsonAsync<List<Studio>>();
            }
        }
    }
}
