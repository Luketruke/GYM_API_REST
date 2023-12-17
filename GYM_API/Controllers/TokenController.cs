using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GYM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration, ILoginService loginService, IPasswordService passwordService)
        {
            _configuration = configuration;
            _loginService = loginService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<(bool, Security)> IsValidUser(UserLogin login)
        {
            var user = await _loginService.GetLoginByCredentials(login);
            var isValid = _passwordService.Check(user.Password, login.Password);

            return (isValid, user);
        }

        private string GenerateToken(Security security)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKet"]));
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.UserName),
                //new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, security.Role.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claims,
            DateTime.Now,
            DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}