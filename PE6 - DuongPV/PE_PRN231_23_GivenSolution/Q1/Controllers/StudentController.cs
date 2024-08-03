using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1.Models;
using System.Globalization;
using System.IO;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly PE_PRN_LUONGNP3Context _context;
        private readonly IMapper _mapper;

        public StudentController(PE_PRN_LUONGNP3Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet("List")]
        public IActionResult Get()
        {
            var listStudent = _context.Students.Select(s => new StudentDTO
            {
                Id = s.Id,
                FullName = s.FullName,
                Gender = s.Male ? "Male" : "Female",
                Dob = s.Dob.ToShortDateString(),
                LecturerName = s.Lecture.FullName,
                Age = DateTime.Now.Year - s.Dob.Year
            })
                                            .ToList();

            return Ok(listStudent);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.Where(s => s.Id == id)
                .Select(s => new
            {
                studentId = s.Id,
                fullName = s.FullName,
                gender = s.Male ? "Male" : "Female",
                dob = s.Dob,
                lecturerName = s.Lecture.FullName,
                age = DateTime.Now.Year - s.Dob.Year,
                classes = s.Classes,
                subjects = s.StudentSubjects,
                CPA = CalculateCPA(s.StudentSubjects)
            })
                                           .FirstOrDefault();
            return Ok(student);
        }

        private static double CalculateCPA(ICollection<StudentSubject> subjectList)
        {
            double totalCPA = 0;
            foreach (var subject in subjectList)
            {
                totalCPA += subject.Grade;
            }
            totalCPA = totalCPA / subjectList.Count();
            return totalCPA;
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var studentFound = _context.Students.Where(s => s.Id == id)
                                .Include(s => s.StudentSubjects)
                                .Include(s => s.Classes)
                                .FirstOrDefault();
                if (studentFound == null)
                {
                    return NotFound();
                }
                else
                {
                    studentFound.StudentSubjects.Clear();
                    studentFound.Classes.Clear();
                    _context.Students.Remove(studentFound);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting student: {ex}");
                return Conflict("There was an unknown error when performing data deletion.");
            }
        }



    }

}