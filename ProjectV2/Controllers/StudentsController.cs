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

        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;

            _mapper = mapper;
        }

        [Authorize(Roles = "Teacher , Admin")]
        [HttpGet("GetAllStudents")]
        public ActionResult<IEnumerable<Users>> GetStudents()
        {
            var studs = _studentRepository.GetStudents();
            if (studs == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(studs));
        }

        [Authorize(Roles = "Teacher , Admin")]
        [HttpGet("GetStudentByID")]
        public ActionResult<IEnumerable<Users>> GetStudentByID(int ID)
        {
            var student = _studentRepository.GetStudentByID(ID);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(student));
        }
    }
}