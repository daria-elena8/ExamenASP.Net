using examen.Repositories.GenericRepository;
using examen.Models;

namespace examen.Repositories.ActorRepository
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        List<Actor> OrderByAge(int age);
    }
}
