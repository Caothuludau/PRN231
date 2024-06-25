using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
        public class EmployeeController : Controller
        {
            private readonly PE_PRN_23SumContext _context;

            public EmployeeController (PE_PRN_23SumContext context)
            {
                _context = context;
            }

            [HttpGet("Index")]
            public IActionResult GetAllEmployee()
            {
                var listEmployee = _context.Employees.Select(e => new
                {
                    employeeId = e.EmployeeId,
                    lastName = e.LastName,
                    firstName = e.FirstName,
                    fullName = e.FirstName + " " + e.LastName,
                    title = e.Title,
                    titleOfCourtesy = e.TitleOfCourtesy,
                    birthDate = e.BirthDate,
                    birthDateStr = e.BirthDate.Value.ToShortDateString(),
                    reportsTo = (e.ReportsTo != null || e.ReportsToNavigation.FirstName.Length != 0) ? e.ReportsToNavigation.FirstName + " " + e.ReportsToNavigation.LastName : "No one"
                })
                .ToList();
                return Ok(listEmployee);
            }


        [HttpGet("List/{minyear}/{maxyear}")]
        public IActionResult GetEmployeeByYear(string minyear, string maxyear)
        {
            DateTime min = new DateTime(Int32.Parse(minyear), 1, 1);
            DateTime max = new DateTime(Int32.Parse(maxyear), 12, 31);

            var listEmployee = _context.Employees
                .Where(e => e.HireDate >= min && e.HireDate <= max)
                .Select(e => new
            {
                employeeId = e.EmployeeId,
                lastName = e.LastName,
                firstName = e.FirstName,
                fullName = e.FirstName + " " + e.LastName,
                title = e.Title,
                titleOfCourtesy = e.TitleOfCourtesy,
                birthDate = e.BirthDate,
                birthDateStr = e.BirthDate.Value.ToShortDateString(),
                reportsTo = (e.ReportsTo != null || e.ReportsToNavigation.FirstName.Length != 0) ? e.ReportsToNavigation.FirstName + " " + e.ReportsToNavigation.LastName : "No one"
            })
            .ToList();
            return Ok(listEmployee);
        }


        [HttpPost("Delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employeeFound = _context.Employees.Where(c => c.EmployeeId == id)
                                .Include(c => c.Orders)
                                .FirstOrDefault();
                if (employeeFound == null)
                {
                    return NotFound("The requested employee cound not be found");
                }
                else
                {
                    // If customer found, delete associated orders
                    _context.OrderDetails.RemoveRange(employeeFound.Orders.SelectMany(o => o.OrderDetails));
                    _context.Orders.RemoveRange(employeeFound.Orders);

                    var managerList = _context.Employees.Where(c => c.ReportsTo == id);
                    foreach (var m in managerList) {
                        m.ReportsTo = null;
                    }

                    _context.Employees.Remove(employeeFound);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting employee: {ex}");

                // Return Conflict response with the specified message
                return Conflict("There was an unknown error when performing data deletion.");
            }





        }
    }
}
