using examen.Models;
using examen.Repositories.GenericRepository;
using examen.Repositories.UserRepository;
using examen.Data;
using examen.Helpers.Extensions;

namespace examen.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(examenContext examenContext) : base(examenContext)
        {
        }

        /*
        public List<User> FindAllActive()
        {
            return _table.GetActiveUsers().ToList();
        }
        */

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
