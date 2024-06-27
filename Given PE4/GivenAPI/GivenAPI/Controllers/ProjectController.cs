using GivenAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace PRN231_Q1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            List<Project> list = new List<Project>
            {
                new Project{ProjectId= 1, ProjectName = "Project Alpha"},
                new Project{ProjectId= 2, ProjectName = "Project Beta"},
                new Project{ProjectId= 3, ProjectName = "Project Gamma"},
                new Project{ProjectId= 4, ProjectName = "Project Delta"}
            };
            return Ok(list);
        }

    }

    
}
