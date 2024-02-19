using examen.Models.Base;
using examen.Models.One_to_Many;

namespace examen.Models
{
    public class Movie : BaseEntity
    {
        public string? MovieName { get; set; }
        public string? Rating { get; set; }
        public DateTime? DateAppeared { get; set; }
        public string? Genres { get; set; }

        public ICollection<Model1>? Models1 { get; set; }
    }
}
