using Microsoft.AspNetCore.Mvc;
using GivenAPI.Models;

namespace PRN231_Q1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee (1, "Employee 1"),
                new Employee (2, "Employee 2"),
                new Employee (3, "Employee 3"),
                new Employee (4, "Employee 4"),
            };
            return Ok(list);
        }
    }

    
}
