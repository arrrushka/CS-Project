using Microsoft.EntityFrameworkCore;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.BLL.Interfaces;
using ScheduleProject.DAL.Context;
using ScheduleProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleProject.BLL.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly schedule_dbContext _dbContext;

        public ScheduleRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public ScheduleModel AddEvent(EventAddDTO newEvent)
        {
            var SubStart = TimeSpan.Parse(newEvent.SubjectStart);
            var SubEnd = TimeSpan.Parse(newEvent.SubjectEnd);

            var Event = new ScheduleModel
            {
                SubjectStart = SubStart,
                SubjectEnd = SubEnd,
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

        public async Task<IEnumerable<ScheduleModel>> ShowMySubjects(string Group)
        {
            return await _dbContext.Schedule.Where(x => x.Group.Equals(Group)).ToArrayAsync();
        }

        public async Task<IEnumerable<ScheduleModel>> ShowMySubjectsByDay(string Group, int Day)
        {
            return await _dbContext.Schedule.Where(x => x.Group.Equals(Group)).Where(x => x.Day.Equals(Day)).ToArrayAsync();
        }
    }
}