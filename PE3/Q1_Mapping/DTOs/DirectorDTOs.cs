using Q1_Mapping.Models;

namespace Q1.DTOs
{
    public class DirectorDTOs
    {
        public DirectorDTOs()
        {

        }

        public string FullName { get; set; } = null!;
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
