using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectV2.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;

            _mapper = mapper;
        }

        [Authorize(Roles = "Teacher , Admin , SuperAdmin")]
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<IEnumerable<Users>>> GetStudents()
        {
            var studs = await _studentRepository.GetStudents();
            if (studs == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(studs));
        }

        [Authorize(Roles = "Teacher , Admin , SuperAdmin")]
        [HttpGet("GetStudentByID")]
        public async Task<ActionResult<IEnumerable<Users>>> GetStudentByID(int ID)
        {
            var student = await _studentRepository.GetStudentByID(ID);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(student));
        }

        [Authorize(Roles = "Teacher , Admin , SuperAdmin")]
        [HttpGet("GetStudentsByGroup")]
        public async Task<ActionResult<IEnumerable<Users>>> GetStudentsByGroup(string Group)
        {
            var students = await _studentRepository.GetStudentsByGroup(Group);
            if (students == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(students));
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMyGroupmates")]
        public async Task<ActionResult<IEnumerable<Users>>> ShowMyGroupmates()
        {
            var Group = await _studentRepository.ShowMyGroupmates(User.FindFirstValue(ClaimTypes.GroupSid));
            if (Group == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(Group));
        }
    }
}