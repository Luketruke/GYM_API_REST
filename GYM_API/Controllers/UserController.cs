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
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetUsers()
        {
            var users = _userRepository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> User(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            await _userRepository.Add(user);
            return Ok(user);
        }
    }
}
