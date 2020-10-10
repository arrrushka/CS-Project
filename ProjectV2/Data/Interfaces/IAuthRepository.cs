using ProjectV2.Models;

namespace ProjectV2.Data.Interfaces
{
    public interface IAuthRepository
    {
        Users Register(Users student, string password);

        Users Login(string username, string password);

        bool UserExists(string username);
    }
}