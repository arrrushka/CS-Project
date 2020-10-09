using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV2.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Users> GetStudents();
    }
}