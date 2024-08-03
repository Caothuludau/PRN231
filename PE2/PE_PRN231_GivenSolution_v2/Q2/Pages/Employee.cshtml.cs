using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Dtos;

namespace Q2.Pages
{
    public class EmployeeModel : PageModel
    {
        private readonly HttpClient _httpClient;

		public EmployeeModel(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        [BindProperty]
        public EmployeeDto employee { get; set; }
        public List<EmployeeDto> Employees { get; set; }

		public void OnGet()
        {
            var response = _httpClient.GetAsync($"http://localhost:5100/api/Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                Employees = response.Content.ReadFromJsonAsync<List<EmployeeDto>>().Result;
            }
        }

        public void OnPost()
        {
            if(employee != null)
            {
                var response = _httpClient.PostAsJsonAsync($"http://localhost:5100/api/Employee", employee).Result;
			}
            OnGet();
        }
    }
}
