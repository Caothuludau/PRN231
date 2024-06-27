using Microsoft.AspNetCore.Mvc;

namespace Q2.Models
{
    public class EmployeeWithSkills
    {
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public string? ProficiencyLevel { get; set; }
        public DateTime? AcquiredDate { get; set; }
    }
}
