using Microsoft.EntityFrameworkCore;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectV2.Data.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly schedule_dbContext _dbContext;

        public ScheduleRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public Schedule AddEvent(EventAddDTO newEvent)
        {
            var Event = new Schedule
            {
                SubjectStart = newEvent.SubjectStart,
                SubjectEnd = newEvent.SubjectEnd,
                Day = newEvent.Day,
                Class = newEvent.Class,
                Group = newEvent.Group,
                Subject = newEvent.Subject,
                Teacher = newEvent.Teacher
            };

            _dbContext.Schedule.Add(Event);
            _dbContext.SaveChanges();

            return Event;
        }

        public async Task<IEnumerable<Schedule>> ShowMySubjects(string Group)
        {
            return await _dbContext.Schedule.Where(x => x.Group.Equals(Group)).ToArrayAsync();
        }

        public async Task<IEnumerable<Schedule>> ShowMySubjectsByDay(string Group, int Day)
        {
            return await _dbContext.Schedule.Where(x => x.Group.Equals(Group)).Where(x => x.Day.Equals(Day)).ToArrayAsync();
        }
    }
}