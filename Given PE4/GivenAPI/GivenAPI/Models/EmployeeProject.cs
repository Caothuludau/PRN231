namespace GivenAPI.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string? Role { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public EmployeeProject(int employeeId, int projectId, string? role, DateTime? joinDate, DateTime? leaveDate)
        {
            EmployeeId = employeeId;
            ProjectId = projectId;
            Role = role;
            JoinDate = joinDate;
            LeaveDate = leaveDate;
        }
    }
}
