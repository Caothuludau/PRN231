using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE4.Models;

namespace PE4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly PE_PRN_24SpringB1Context _context;
        public EmployeeController(PE_PRN_24SpringB1Context context)
        {
            _context = context;
        }

        [HttpPost("Delete/{EmployeeId}")]
        public IActionResult deleteEmployee(int EmployeeId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var empFound = _context.Employees.Where(c => c.EmployeeId == EmployeeId)
                                .Include(c => c.EmployeeProjects)
                                .Include(e => e.EmployeeSkills)
                                .FirstOrDefault();
                if (empFound == null)
                {
                    return NotFound($"No employee with id {EmployeeId}");
                }
                else
                {
                    
                    int employeeProjectsCount = empFound.EmployeeProjects.Count;
                    int employeeSkillsCount = empFound.EmployeeSkills.Count;
                    var departmentsManaged = _context.Departments.Where(d => d.ManagerId == EmployeeId);
                    int departmentManagesCount = departmentsManaged.Count();

                    foreach (var department in departmentsManaged)
                    {
                        department.ManagerId = null;
                        _context.SaveChanges();
                    }

                    _context.EmployeeProjects.RemoveRange(empFound.EmployeeProjects);
                    _context.EmployeeSkills.RemoveRange(empFound.EmployeeSkills);
                    _context.Departments.RemoveRange(departmentsManaged);

                    _context.Employees.Remove(empFound);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Ok(new
                    {
                        numberOfProjects = employeeProjectsCount,
                        numberOfSkills = employeeSkillsCount,
                        departmentsCount = departmentManagesCount
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting customer: {ex}");

                transaction.Rollback();
                // Return Conflict response with the specified message
                return Conflict("There was an unknown error when performing data deletion.");
            }
        }

    }
}
