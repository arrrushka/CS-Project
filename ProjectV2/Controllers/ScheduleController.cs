using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;

namespace ProjectV2.Controllers
{
    [Route("api/[controller]")]
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
        }
    }
}