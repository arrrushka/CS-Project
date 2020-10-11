using ProjectV2.Models;
using System.Collections.Generic;

namespace ProjectV2.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Users> GetStudents();

        IEnumerable<Users> GetStudentByID(int ID);

        IEnumerable<Users> GetStudentsByGroup(string Group);

        IEnumerable<Users> ShowMyGroupmates(string Group);
    }
}