using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Repositories;

namespace GYM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private readonly IRepository<Fighter> _fighterRepository;
        private readonly IMapper _mapper;
        public FighterController(IRepository<Fighter> fighterRepository, IMapper mapper)
        {
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetFighters()
        {
            var fighters = _fighterRepository.GetAll();
            var fightersDto = _mapper.Map<IEnumerable<FighterDto>>(fighters);
            return Ok(fightersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFighter(int id)
        {
            var fighter = await _fighterRepository.GetById(id);
            var fighterDto = _mapper.Map<IEnumerable<FighterDto>>(fighter);
            return Ok(fighterDto);
        }

        [HttpPost]
        public async Task<IActionResult> Fighter(FighterDto fighterDto)
        {
            var fighter = _mapper.Map<Fighter>(fighterDto);

            await _fighterRepository.Add(fighter);
            return Ok(fighter);
        }
    }
}
