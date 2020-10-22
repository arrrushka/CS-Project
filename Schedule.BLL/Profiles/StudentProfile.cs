using AutoMapper;
using ProjectV2.DTOs;
using ProjectV2.Models;

namespace ProjectV2.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Users, StudentDTO>();
        }
    }
}