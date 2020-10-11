using ProjectV2.Data.Interfaces;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectV2.Data.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly schedule_dbContext _dbContext;

        public ScheduleRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public IEnumerable<Schedule> ShowMySubjects(string Group)
        {
            return _dbContext.Schedule.Where(x => x.Group.Equals(Group));
        }
    }
}