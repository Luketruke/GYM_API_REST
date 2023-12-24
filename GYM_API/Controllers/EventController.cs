using AutoMapper;
using GYM.Api.Responses;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Interfaces.Repositories;
using GYM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GYM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public EventController(IRepository<Event> eventRepository, IMapper mapper, IEventService eventService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _eventService = eventService;
        }

        [HttpGet]

        public IActionResult GetEvents()
        {
            var events = _eventRepository.GetAll();
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);
            return Ok(eventsDto);
        }

        /// <summary>
        /// Get Fighter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventt = await _eventService.GetEvent(id);

            if (eventt != null)
            {
                var eventDto = _mapper.Map<EventDto>(eventt);
                var response = new ApiResponse<EventDto>(eventDto);
                return Ok(response);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Event(EventDto eventDto)
        {
            var eventt = _mapper.Map<Event>(eventDto);

            await _eventRepository.Add(eventt);
            return Ok(eventt);
        }
    }
}
