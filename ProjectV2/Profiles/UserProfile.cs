using AutoMapper;
using ProjectV2.DTOs;
using ProjectV2.Models;

namespace ProjectV2.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserRegisterDTO>();
            CreateMap<Users, UserLoginDTO>();
        }
    }
}