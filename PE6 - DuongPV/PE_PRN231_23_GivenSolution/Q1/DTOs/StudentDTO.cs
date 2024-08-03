using System.ComponentModel.DataAnnotations;

namespace Q1.DTOs
{
    public class StudentDTO
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? Dob { get; set; }
        public string? LecturerName { get; set; }
        public int? Age { get; set; }
    }
}
