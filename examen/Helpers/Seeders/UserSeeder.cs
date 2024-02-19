using examen.Models;
using examen.Data;

namespace examen.Helpers.Seeders
{
    public class UsersSeeder
    {
        public readonly examenContext _examenContext;

        public UsersSeeder(examenContext examenContext)
        {
            _examenContext = examenContext;
        }

        public void SeedInitialUsers()
        {
            if (!_examenContext.Users.Any())
            {
                var user1 = new User
                {
                    FirstName = "Fist name User 1",
                    LastName = "Last name User 1",
                    IsDeleted = false,
                    Email = "user1@mail.com",
                    Username = "user1"
                };

                var user2 = new User
                {
                    FirstName = "Fist name User 2",
                    LastName = "Last name User 2",
                    IsDeleted = false,
                    Email = "user2@mail.com",
                    Username = "user2"
                };

                _examenContext.Users.Add(user1);
                _examenContext.Users.Add(user2);

                _examenContext.SaveChanges();
            }
        }
    }
}
