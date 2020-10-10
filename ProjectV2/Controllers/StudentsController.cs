using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;

namespace ProjectV2.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IScheduleRepository scheduleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;

            _mapper = mapper;
        }

        [Authorize(Roles = Role.Teacher)]
        [HttpGet("students")]
        public ActionResult<IEnumerable<Users>> GetStudents()
        {
            var studs = _studentRepository.GetStudents();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(studs));
        }

        [Authorize(Roles = Role.Teacher)]
        [HttpGet("GetStudentByID")]
        public ActionResult<IEnumerable<Users>> GetStudentByID(int ID)
        {
            var student = _studentRepository.GetStudentByID(ID);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(student));
        }
    }
}