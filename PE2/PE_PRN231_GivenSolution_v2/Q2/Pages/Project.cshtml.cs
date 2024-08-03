using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Dtos;

namespace Q2.Pages
{
	public class ProjectModel : PageModel
	{
		private readonly HttpClient _httpClient;

		public ProjectModel(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		[BindProperty]
		public ProjectDto project { get; set; }
		public List<ProjectDto> projects { get; set; }

		public void OnGet()
		{
			var response = _httpClient.GetAsync("http://localhost:5100/api/Project").Result;
			if (response.IsSuccessStatusCode)
			{
				projects = response.Content.ReadFromJsonAsync<List<ProjectDto>>().Result;
			}
		}

		public void OnPost()
		{
			if (project != null)
			{
				if (project.StartDate > project.EndDate)
				{
					TempData["mess"] = "End date not better than Start date";
				}
				else
				{
					var response = _httpClient.PostAsJsonAsync("http://localhost:5100/api/Project", project).Result;
				}
			}
			OnGet();
		}
	}
}
