namespace Q2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? DepartmentId { get; set; }
        public string? Position { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
