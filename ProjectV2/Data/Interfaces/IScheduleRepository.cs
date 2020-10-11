using ProjectV2.Models;
using System.Collections.Generic;

namespace ProjectV2.Data.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> ShowMySubjects(string Group);
    }
}