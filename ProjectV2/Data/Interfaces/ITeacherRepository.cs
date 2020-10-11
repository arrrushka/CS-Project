using ProjectV2.Models;
using System.Collections.Generic;

namespace ProjectV2.Data.Interfaces
{
    public interface ITeacherRepository
    {
        IEnumerable<Users> GetTeachers();

        IEnumerable<Users> GetTeacherByID(int ID);
    }
}