using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;
using System.Collections.Generic;

namespace ProjectV2.Controllers
{
    [Authorize]
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public AdminController(IStudentRepository studentRepository, IScheduleRepository scheduleRepository, ITeacherRepository teacherRepository, IMapper mapper, IUserRepository userRepository)
        {
            _scheduleRepository = scheduleRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetAllTeachers")]
        public ActionResult<IEnumerable<Users>> GetAllTeachers()
        {
            var Teachers = _teacherRepository.GetTeachers();
            if (Teachers == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<TeacherDTO>>(Teachers));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetTeacherByID")]
        public ActionResult<IEnumerable<Users>> GeTeacherID(int ID)
        {
            var Teacher = _teacherRepository.GetTeacherByID(ID);
            if (Teacher == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<TeacherDTO>>(Teacher));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("SetAsTeacher")]
        public ActionResult SetAsTeacher(string Username)
        {
            var update = _userRepository.SetAsTeacher(Username);
            if (update == false) return BadRequest();
            return Ok("Role changed");
        }
    }
}