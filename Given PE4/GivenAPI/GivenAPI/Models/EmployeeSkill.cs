namespace GivenAPI.Models
{
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public string? ProficiencyLevel { get; set; }
        public DateTime? AcquiredDate { get; set; }

        public EmployeeSkill(int employeeId, int skillId, string? proficiencyLevel, DateTime? acquiredDate)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
            ProficiencyLevel = proficiencyLevel;
            AcquiredDate = acquiredDate;
        }
    }
}
