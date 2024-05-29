using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1.Models;
using SQLitePCL;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly PE_PRN_Fall22B1Context _context;
        public DirectorController(PE_PRN_Fall22B1Context context)
        {
            _context = context;
        }

        [HttpGet("getAllDirectors")]
        public IActionResult getAllDirector()
        {
            var listDirector = _context.Directors.ToList();
            return Ok(listDirector);
        }

        [HttpGet("getdirectors/{nationality}/{gender}")]
        public IActionResult getDirectors(string nationality, string gender)
        {
            bool isMale = false;
            if (gender == null /*|| gender.ToUpper() != "MALE" || gender.ToUpper() != "FEMALE"*/) { return NotFound(); }
            else
            {
                if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase)) { isMale = true; }

                var listDirector = _context.Directors.Where(x => x.Nationality.Equals(nationality) && x.Male == isMale)
                    .Select(d => new DirectorDTOs()
                    {
                        Id = d.Id,
                        FullName = d.FullName,
                        Gender = d.Male ? "Male" : "Female",
                        Dob = d.Dob,
                        DobString = d.Dob.ToString("MM/dd/yyyy"),
                        Nationality = d.Nationality,
                        Description = d.Description
                    })
                    .ToList();


                return Ok(listDirector);
            }
        }

        [HttpGet("getdirector/{id}")]
        public IActionResult getDirector(int id)
        {
            var director = _context.Directors.Where(d => d.Id == id)
                .Select(d => new DirectorDTOs()
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Gender = d.Male ? "Male" : "Female",
                    Dob = d.Dob,
                    DobString = d.Dob.ToString("MM/dd/yyyy"),
                    Nationality = d.Nationality,
                    Description = d.Description,
                    MovieDTOs = d.Movies.Select(m => new MovieDTOs
                    {
                        Id = m.Id,
                        Title = m.Title,
                        ReleaseDate = m.ReleaseDate,
                        ReleaseYear = m.ReleaseDate.Value.ToString("MM/dd/yyyy"),
                        Description = m.Description,
                        Language = m.Language,
                        ProducerId = m.ProducerId,
                        DirectorId = m.DirectorId,
                        ProducerName = m.Producer.Name,
                        DirectorName = m.Director.FullName
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return Ok(director);
        }


        [HttpPost("director/create")]
        public IActionResult addDirector(List<Director> listDirector)
        {
            if (listDirector == null)
            {
                return BadRequest("Invalid input data.");
            }
            else
            {
                foreach (Director director in listDirector)
                {
                    if (string.IsNullOrEmpty(director.FullName))
                    {
                        return BadRequest("Invalid input data.");
                    }

                    try
                    {
                        var d = new Director
                        {
                            FullName = director.FullName,
                            Male = director.Male,
                            Dob = director.Dob,
                            Nationality = director.Nationality,
                            Description = director.Description
                        };

                        _context.Directors.Add(d);
                    }
                    catch (Exception ex)
                    {
                        return Conflict(new { message = "There is an error while adding.", error = ex.Message });
                    }
                }

                var recordsAdded = _context.SaveChanges();

                return Ok(recordsAdded);
            }
        }
    }
}
