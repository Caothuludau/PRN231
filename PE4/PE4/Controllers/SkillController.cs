using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE4.Models;

namespace PE4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly PE_PRN_24SpringB1Context _context;
        public SkillController(PE_PRN_24SpringB1Context context)
        {
            _context = context;
        }

        [HttpGet("GetSkills")]
        public IActionResult getSkills()
        {
            var listSkill = _context.Skills
                .Select(x => new
                {
                    skillId = x.SkillId,
                    skillName = x.SkillName,
                    description = x.Description,
                    numberOfEmployee = x.EmployeeSkills.Count()
                })
                .ToList();
            return Ok(listSkill);
        }

        [HttpGet("GetSkill/{skillId}")]
        public IActionResult getSkill(int skillId)
        {
            var skill = _context.Skills
                                .Where(d => d.SkillId == skillId)
                                .Select(x => new
                                {
                                    skillId = x.SkillId,
                                    skillName = x.SkillName,
                                    description = x.Description,
                                    employees = x.EmployeeSkills
                                        .Select(es => new
                                        {
                                            employeeId = es.EmployeeId,
                                            employeeName = es.Employee.Name,
                                            department = es.Employee.Department.DepartmentName,
                                            proficiencyLevel = es.ProficiencyLevel,
                                            acquiredDate = es.AcquiredDate
                                        })
                                })
                                .FirstOrDefault();
            if (skill != null) return Ok(skill);
            else return NotFound();
        }
    }
}
