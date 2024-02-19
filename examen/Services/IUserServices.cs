using examen.Models.DTOs;
using examen.Models;

namespace examen.Services.UserServices
{
    public interface IUserServices
    {
        Task<List<UserDto>> GetAllUsers();

        UserDto GetUserByUsername(string username);
    }
}
