using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Security.Cryptography;
using Q2.Models;

namespace Q2.Pages.Home
{
    public class EmployeeWithSkillModel : PageModel
    {
        public List<Employee> rs1 { get; set; }
        public void OnGet()
        {
            HttpClient _httpClient = new HttpClient();
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:5100/api/Employee/List").Result;
            var employees = response.Content.ReadFromJsonAsync<List<Employee>>().Result;
            rs1 = new List<Employee>();
            rs1 = employees.ToList();
            ViewData["API"] = employees.ToList();

            HttpResponseMessage responseSkill = _httpClient.GetAsync("http://localhost:5100/api/Skill/List").Result;
            var skills = responseSkill.Content.ReadFromJsonAsync<List<Skill>>().Result;
            ViewData["skills"] = skills.ToList();

            HttpResponseMessage responseEmployeSkill = _httpClient.GetAsync("http://localhost:5100/api/EmployeeSkill/List").Result;
            var EmployeSkill = responseEmployeSkill.Content.ReadFromJsonAsync<List<EmployeeWithSkills>>().Result;
            ViewData["EmployeSkill"] = EmployeSkill.ToList();
        }
    }
}
