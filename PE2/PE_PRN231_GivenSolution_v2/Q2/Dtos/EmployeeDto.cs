namespace Q2.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Position { get; set; }
        public bool IsFulltime { get; set; }
    }
}
