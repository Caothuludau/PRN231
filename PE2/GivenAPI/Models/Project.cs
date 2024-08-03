namespace GivenAPI.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public DateOnly StartDate { get; set; } 
        public DateOnly? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
