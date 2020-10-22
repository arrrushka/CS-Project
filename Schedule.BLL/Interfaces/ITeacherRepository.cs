using ProjectV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectV2.Data.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Users>> GetTeachers();

        Task<IEnumerable<Users>> GetTeacherByID(int ID);
    }
}