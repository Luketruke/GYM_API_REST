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
    public class FightController : ControllerBase
    {
        private readonly IRepository<Fight> _fightRepository;
        private readonly IMapper _mapper;
        public FightController(IRepository<Fight> fightRepository, IMapper mapper)
        {
            _fightRepository = fightRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetFights()
        {
            var fights = _fightRepository.GetAll();
            var fightsDto = _mapper.Map<IEnumerable<FightDto>>(fights);
            return Ok(fightsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFight(int id)
        {
            var fight = await _fightRepository.GetById(id);
            var fightDto = _mapper.Map<IEnumerable<FightDto>>(fight);
            return Ok(fightDto);
        }

        [HttpPost]
        public async Task<IActionResult> Fight(FightDto fightDto)
        {
            var fight = _mapper.Map<Fight>(fightDto);

            await _fightRepository.Add(fight);
            return Ok(fight);
        }
    }
}
