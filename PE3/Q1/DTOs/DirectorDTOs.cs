using Q1.Models;

namespace Q1.DTOs
{
    public class DirectorDTOs
    {
        public DirectorDTOs()
        {

            MovieDTOs = new HashSet<MovieDTOs>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string DobString { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<MovieDTOs> MovieDTOs { get; set; }

    }
}
