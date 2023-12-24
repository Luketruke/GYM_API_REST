using AutoMapper;
using GYM.Api.Responses;
using GYM.Core.Enumerators;
using GYM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace GYM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Genders
        /// </summary>
        /// <returns></returns>
        [HttpGet("getgenders", Name = nameof(GetGenders))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GenderEnum>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<IEnumerable<GenderEnum>> GetGenders()
        {
            var genders = _genderService.GetGenders();
            return Ok(new ApiResponse<IEnumerable<string>>(genders));
        }

        /// <summary>
        /// Get Gender By Name
        /// </summary>
        /// <param name="genderName"></param>
        /// <returns></returns>
        [HttpGet("gender")]
        public IActionResult GetGenderByName(string genderName)
        {
            try
            {
                var gender = _genderService.GetGender(genderName);
                return Ok(new ApiResponse<GenderEnum>(gender));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }
    }
}
