﻿namespace Q2.DTOs
{
    public class StudentDTO
    {
        public StudentDTO() { }
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Dob { get; set; } = null!;
        public string LecturerName { get; set; } = null!;
        public int Age { get; set; }
    }
}