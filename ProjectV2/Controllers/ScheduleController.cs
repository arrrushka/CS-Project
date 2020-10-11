using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectV2.Controllers
{
    [Authorize]
    [Route("api/Schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;

            _mapper = mapper;
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMySubjects")]
        public ActionResult<IEnumerable<Schedule>> ShowMySubjects()
        {
            var Schedule = _scheduleRepository.ShowMySubjects(User.FindFirstValue(ClaimTypes.GroupSid));
            if (Schedule == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(Schedule));
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMySubjectsByDay")]
        public ActionResult<IEnumerable<Schedule>> ShowMySubjectsByDay(int Day)
        {
            var Schedule = _scheduleRepository.ShowMySubjectsByDay(User.FindFirstValue(ClaimTypes.GroupSid), Day);
            if (Schedule == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(Schedule));
        }
    }
}