using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Infrastructure.Repositories;
using GYM.Core.Interfaces.Repositories;

namespace GYM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public EventController(IRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetEvents()
        {
            var events = _eventRepository.GetAll();
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);
            return Ok(eventsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var eventt = await _eventRepository.GetById(id);
            var eventDto = _mapper.Map<IEnumerable<EventDto>>(eventt);
            return Ok(eventDto);
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
