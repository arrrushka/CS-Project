﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.BLL.Interfaces;
using ScheduleProject.BLL.Role;
using ScheduleProject.DAL.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScheduleProject.WEB.Controller
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
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ShowMySubjects()
        {
            var schedule = await _scheduleRepository.ShowMySubjects(User.FindFirstValue(ClaimTypes.GroupSid));

            if (schedule == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(schedule));
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMySubjectsByDay")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ShowMySubjectsByDay(int day)
        {
            var schedule = await _scheduleRepository.ShowMySubjectsByDay(User.FindFirstValue(ClaimTypes.GroupSid), day);
            if (schedule == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(schedule));
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost("AddEvent")]
        public ActionResult AddEvent(EventAddDTO newEvent)
        {
            var Event = _scheduleRepository.AddEvent(newEvent);
            if (Event == null) return BadRequest("Oops, something went wrong...");
            return StatusCode(201);
        }
    }
}