using examen.Models.Base;
using examen.Models.One_to_Many;

namespace examen.Models
{
    public class Actor : BaseEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }

        public ICollection<Model1>? Models1 { get; set; }
    }
}
