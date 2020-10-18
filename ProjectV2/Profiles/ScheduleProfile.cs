using AutoMapper;
using ProjectV2.DTOs;
using ProjectV2.Models;

namespace ProjectV2.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<Schedule, EventAddDTO>();
        }
    }
}