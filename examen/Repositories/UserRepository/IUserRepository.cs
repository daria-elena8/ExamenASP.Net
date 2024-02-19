using examen.Models;
using examen.Repositories.GenericRepository;

namespace examen.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername(string username);

        //List<User> FindAllActive();
    }
}
