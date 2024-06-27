using GivenAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace PRN231_Q1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SkillController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            List<Skill> list = new List<Skill>
            {
                new Skill{SkillId= 1, SkillName = "Java"},
                new Skill{SkillId= 2, SkillName = "Python"},
                new Skill{SkillId= 3, SkillName = "Project Management"},
                new Skill{SkillId= 4, SkillName = "Communication"}
            };
            return Ok(list);
        }

    }

    
}
