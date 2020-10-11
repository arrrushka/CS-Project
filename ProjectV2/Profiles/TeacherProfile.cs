using AutoMapper;
using ProjectV2.DTOs;
using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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