namespace Q2.DTOs
{
    public class StudentDetailDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Dob { get; set; } = null!;
        public string LecturerName { get; set; } = null!;
        public int Age { get; set; }
        public  ICollection<SubjectDTO> Subjects { get; set; }
        public  ICollection<ClassDTO> Classes { get; set; }
    }
}
