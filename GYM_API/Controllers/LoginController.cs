using AutoMapper;
using GYM.Api.Responses;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYM.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public LoginController(ILoginService loginService, IMapper mapper, IPasswordService passwordService)
        {
            _loginService = loginService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        /// <summary>
        /// Register your user
        /// </summary>
        /// <param name="securityDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);

            securityDto.status = 1;

            security.Password = _passwordService.Hash(security.Password);
            await _loginService.RegisterUser(security);

            // Map the saved Security entity back to SecurityDto
            var savedSecurity = await _loginService.GetLoginByCredentials(new UserLogin { /* Provide login details if needed */ });
            var savedSecurityDto = _mapper.Map<SecurityDto>(savedSecurity);

            var response = new ApiResponse<SecurityDto>(savedSecurityDto);

            return Ok(response);
        }

    }
}
