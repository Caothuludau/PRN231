using Microsoft.AspNetCore.Mvc;
using GivenAPI.Models;

namespace PRN231_Q1.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok(MyDbContext.Employees);
        }

        [HttpPost]
        public IActionResult AddNewEmployee([FromBody] Employee employee)
        {
            if (MyDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId) != null)
                return Conflict();
            else
            {
                MyDbContext.Employees.Add(employee);
                return Ok();
            }
        }
    }

    
}
