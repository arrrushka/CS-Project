using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;
using System.Collections.Generic;

namespace ProjectV2.Controllers
{
    [Route("api/Schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public ScheduleController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IScheduleRepository scheduleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;

            _mapper = mapper;
        }
    }
}