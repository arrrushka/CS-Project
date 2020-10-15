using ProjectV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectV2.Data.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Users>> GetStudents();

        Task<IEnumerable<Users>> GetStudentByID(int ID);

        Task<IEnumerable<Users>> GetStudentsByGroup(string Group);

        Task<IEnumerable<Users>> ShowMyGroupmates(string Group);
    }
}