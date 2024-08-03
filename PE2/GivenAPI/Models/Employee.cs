namespace GivenAPI.Models
{
    public class Employee
    {
        public Employee()
        {

        }


        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; }
        public DateOnly? Dob { get; set; }
        public string? Position { get; set; }
        public bool? IsFulltime { get; set; }
    }
}
