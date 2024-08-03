using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Q1.DTOs;
using Q1.Models;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : Controller
    {
        private PE_PRN231_Trial_02Context _context = new PE_PRN231_Trial_02Context();

        private readonly IConfiguration _configuration;
        public DirectorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetDirectors/{nationality}/{gender}")]
        public IActionResult Get(string nationality, string gender)
        {
            var listObject = _context.Directors
                .Where(o => o.Nationality.Equals(nationality) && (o.Male ? "Male" : "Female").Equals(gender))
                .Select(o => new
                {
                    id = o.Id,
                    fullName = o.FullName,
                    gender = o.Male ? "Male" : "Female",
                    dob = o.Dob,
                    dobString = o.Dob.ToString("MM/dd/yyyy"),
                    nationality = o.Nationality,
                    description = o.Description
                })
                .ToList();

            return Ok(listObject);
        }

        [HttpGet("GetDirectors/{id}")]
        public IActionResult GetId(int id)
        {
            var listObject = _context.Directors
                            .Where(o => o.Id == id)
                            .Select(o => new
                            {
                                id = o.Id,
                                fullName = o.FullName,
                                gender = o.Male ? "Male" : "Female",
                                dob = o.Dob,
                                dobString = o.Dob.ToString("MM/dd/yyyy"),
                                nationality = o.Nationality,
                                description = o.Description,
                                movies = o.Movies.Select(p => new
                                {
                                    id = p.Id,
                                    title = p.Title,
                                    releaseDate = p.ReleaseDate,
                                    releaseYear = p.ReleaseDate.Value.Year,
                                    description = p.Description,
                                    language = p.Language,
                                    producerId = p.ProducerId,
                                    directorId = p.DirectorId,
                                    producerName = p.Producer.Name,
                                    directorName = p.Director.FullName,
                                    genres = new List<Genre>(),
                                    stars = new List<Star>()
                                })
                            })
                            .ToList();

            return Ok(listObject);
        }

        [HttpPost("/api/Movie/RemoveStarFromMovie/{movieId}/{starId}")]
        public IActionResult Remove(int movieId, int starId)
        {
            try
            {
                var movieFound = _context.Movies.Where(o => o.Id == movieId)
                                .Include(o => o.Stars)
                                .FirstOrDefault();

                if (movieFound == null)
                {
                    return NotFound("The requested movie could not be found.");
                }

                else
                {
                    var starFound = _context.Stars.Where(o => o.Id == starId && o.Movies.Contains(movieFound))
                                .FirstOrDefault();
                    if (starFound == null)
                    {
                        return NotFound("The requested actor could not be found in the list of actors of the requested movie.");
                    }
                    else
                    {
                        movieFound.Stars.Remove(starFound);
                        _context.SaveChanges();
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return Conflict();
            }

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

