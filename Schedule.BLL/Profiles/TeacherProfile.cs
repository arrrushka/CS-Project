using AutoMapper;
using ProjectV2.DTOs;
using ProjectV2.Models;

namespace ProjectV2.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Users, TeacherDTO>();
        }
    }
}