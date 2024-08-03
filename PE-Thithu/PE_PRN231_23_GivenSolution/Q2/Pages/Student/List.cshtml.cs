using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.DTOs;

namespace Q2.Pages.Student
{
    public class ListModel : PageModel
    {
        public List<StudentDTO> students { get; set; }
        public StudentDetailDTO studentDetail { get; set; }
        public async Task<PageResult> OnGetAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5000/api/Student/List");
            if (response.IsSuccessStatusCode)
            {
                students = await response.Content.ReadFromJsonAsync<List<StudentDTO>>();
            }
            return Page();
        }

        public async Task<PageResult> OnGetDetailAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:5000/api/Student/Detail/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["mode"] = "detail";
                studentDetail = await response.Content.ReadFromJsonAsync<StudentDetailDTO>();
            }
            return await OnGetAsync();
        }

        public async Task<PageResult> OnGetDeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:5000/api/Student/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["mode"] = "delete";
            }
            return await OnGetAsync();
        }

    }
}
