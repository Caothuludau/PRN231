using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1_Mapping.Models;

namespace Q1_Mapping.Controllers
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
            if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase)) { isMale = true; }
            var listDirector = _context.Directors
                                .Where(d => d.Nationality == nationality && d.Male == isMale)
                                .Select(d => new
                                {
                                    id = d.Id,
                                    fullName = d.FullName,
                                    gender = d.Male ? "Male" : "Female",
                                    dob = d.Dob,
                                    dobstring = d.Dob.ToString("MM-dd-yyyy"),
                                    nationality = d.Nationality,
                                    description = d.Description
                                })
                                .ToList();
            return Ok(listDirector);
        }

        [HttpGet("getdirector/{id}")]
        public IActionResult getDirector(int id)
        {
            var director = _context.Directors.Where(d => d.Id == id)
                .Select(d => new
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Gender = d.Male ? "Male" : "Female",
                    Dob = d.Dob,
                    DobString = d.Dob.ToString("MM/dd/yyyy"),
                    Nationality = d.Nationality,
                    Description = d.Description,
                    Movies = d.Movies.Select(m => new
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
                        DirectorName = m.Director.FullName,
                        Genres = m.Genres,
                        Stars = m.Stars
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return Ok(director);
        }

        [HttpPost("director/create")]
        public IActionResult addDirector(DirectorDTOs director)
        {
            if (director == null || string.IsNullOrEmpty(director.FullName))
            {
                return BadRequest("Invalid input data.");
            }
            else
            {
                try
                {
                    bool isMale = false;
                    if (director.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)) { isMale = true; }
                    var d = new Director
                    {
                        FullName = director.FullName,
                        Male = isMale,
                        Dob = director.Dob,
                        Nationality = director.Nationality,
                        Description = director.Description
                    };

                    _context.Directors.Add(d);

                    var recordsAdded = _context.SaveChanges();

                    return Ok(recordsAdded);
                }
                catch (Exception ex)
                {
                    return Conflict(new { message = "There is an error while adding.", error = ex.Message });
                }

            }
        }
    }
}
