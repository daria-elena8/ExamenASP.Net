using examen.Models.Base;

namespace examen.Models.Many_to_Many
{
    public class Model4 : BaseEntity
    {
        public string? Name { get; set; }

        // relation
        public ICollection<ModelsRelation> ModelsRelations { get; set; }
    }
}
