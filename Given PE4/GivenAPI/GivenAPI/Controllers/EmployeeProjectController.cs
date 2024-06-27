using GivenAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GivenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeeProjectController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            List<EmployeeProject> list = new List<EmployeeProject>
            {
                new EmployeeProject(1, 1, "Developer", new DateTime(2022, 1, 7), new DateTime(2022, 12, 5)), 
                new EmployeeProject(1, 2, "Lead Developer", new DateTime(2022, 1, 7), new DateTime(2023, 1, 5)), 
                new EmployeeProject(2, 2, "HR Consultant", new DateTime(2022, 1, 7), new DateTime(2022, 12, 5)), 
                new EmployeeProject(2, 3, "HR Support", null, null), 
                new EmployeeProject(3, 3, "QA Lead", new DateTime(2022, 1, 7), new DateTime(2022, 12, 5)), 
                new EmployeeProject(3, 2, "QA Specialist", new DateTime(2022, 1, 7), new DateTime(2022, 12, 5)), 
            };
            return Ok(list);
        }
    }
}
