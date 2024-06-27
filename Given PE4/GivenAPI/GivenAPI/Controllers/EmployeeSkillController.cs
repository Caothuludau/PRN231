using Microsoft.AspNetCore.Mvc;
using GivenAPI.Models;

namespace GivenAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeeSkillController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            List<EmployeeSkill> list = new List<EmployeeSkill>
            {
                new EmployeeSkill(1, 1, "Expert", new DateTime(2022, 1, 7)),
                new EmployeeSkill(1, 2, "Intermediate", new DateTime(2022, 1, 7)),
                new EmployeeSkill(2, 2, "Expert", new DateTime(2022, 1, 7)),
                new EmployeeSkill(2, 3, "Advanced", new DateTime(2022, 1, 7)),
                new EmployeeSkill(3, 3, null, null),
                new EmployeeSkill(3, 2, "Beginner", new DateTime(2022, 1, 7)),
            };
            return Ok(list);
        }
    }
}
