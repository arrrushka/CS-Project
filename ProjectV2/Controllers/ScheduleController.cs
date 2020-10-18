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
        public async Task<ActionResult<IEnumerable<Schedule>>> ShowMySubjects()
        {
            var Schedule = await _scheduleRepository.ShowMySubjects(User.FindFirstValue(ClaimTypes.GroupSid));

            if (Schedule == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(Schedule));
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMySubjectsByDay")]
        public async Task<ActionResult<IEnumerable<Schedule>>> ShowMySubjectsByDay(int Day)
        {
            var Schedule = await _scheduleRepository.ShowMySubjectsByDay(User.FindFirstValue(ClaimTypes.GroupSid), Day);
            if (Schedule == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(Schedule));
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost("AddEvent")]
        public ActionResult AddEvent(EventAddDTO newEvent)
        {
            var Event = _scheduleRepository.AddEvent(newEvent);
            if (Event == null) return BadRequest();
            return StatusCode(201);
        }
    }
}