using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectV2.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly schedule_dbContext _dbContext;

        public TeacherRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public IEnumerable<Users> GetTeacherByID(int ID)
        {
            return _dbContext.Users.Where(s => s.Role.Equals("Teacher")).Where(s => s.UserId.Equals(ID));
        }

        public IEnumerable<Users> GetTeachers()
        {
            return _dbContext.Users.Where(t => t.Role.Equals("Teacher"));
        }
    }
}