using GivenAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace PRN231_Q1.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok(MyDbContext.Projects);
        }

        [HttpPost]
        public IActionResult AddNewProject([FromBody] Project project)
        {
            if (MyDbContext.Projects!.FirstOrDefault(p => p.ProjectId == project.ProjectId) != null)
                return Conflict();
            else
            {
                MyDbContext.Projects.Add(project);
                return Ok();
            }
        }

    }

    
}
