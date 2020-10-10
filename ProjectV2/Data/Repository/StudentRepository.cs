using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectV2.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly schedule_dbContext _dbContext;

        public StudentRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public IEnumerable<Users> GetStudentByID(int ID)
        {
            return _dbContext.Users.Where(s => s.Role.Equals("Student")).Where(s => s.UserId.Equals(ID));
        }

        public IEnumerable<Users> GetStudents()
        {
            return _dbContext.Users.Where(s => s.Role.Equals("Student"));
        }
    }
}