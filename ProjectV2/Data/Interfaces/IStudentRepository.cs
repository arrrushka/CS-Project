using ProjectV2.Models;
using System.Collections.Generic;

namespace ProjectV2.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Users> GetStudents();

        IEnumerable<Users> GetStudentByID(int ID);
    }
}