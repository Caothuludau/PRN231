namespace GivenAPI.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(int employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? DepartmentId { get; set; }
        public string? Position { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
