using ProjectV2.DTOs;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectV2.Data.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> ShowMySubjects(string Group);

        Task<IEnumerable<Schedule>> ShowMySubjectsByDay(string Group, int Day);

        Schedule AddEvent(EventAddDTO newEvent);
    }
}