using System.Threading.Tasks;

namespace ProjectV2.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SetAsTeacher(string Username);

        Task<bool> SetAsAdmin(string Username);
    }
}