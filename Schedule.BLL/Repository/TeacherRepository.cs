using Microsoft.EntityFrameworkCore;
using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV2.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly schedule_dbContext _dbContext;

        public TeacherRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public async Task<IEnumerable<Users>> GetTeacherByID(int ID)
        {
            return await _dbContext.Users.Where(s => s.Role.Equals("Teacher")).Where(s => s.UserId.Equals(ID)).ToListAsync();
        }

        public async Task<IEnumerable<Users>> GetTeachers()
        {
            return await _dbContext.Users.Where(t => t.Role.Equals("Teacher")).ToArrayAsync();
        }
    }
}