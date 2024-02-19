using examen.Models.Base;
using examen.Models.One_to_Many;

namespace examen.Models
{
    public class ActorMovie : BaseEntity
    {
        public Guid MovieNumber { get; set; }
        public string ActorName { get; set; }
      
        public ICollection<Model2>? Models2 { get; set; }
    }
}
