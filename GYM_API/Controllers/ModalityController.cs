using AutoMapper;
using GYM.Api.Responses;
using GYM.Core.Enumerators;
using GYM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Collections.Generic;
namespace GYM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ModalityController : ControllerBase
    {
        private readonly IModalityService _modalityService;
        private readonly IMapper _mapper;

        public ModalityController(IModalityService modalityService, IMapper mapper)
        {
            _modalityService = modalityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Modalities
        /// </summary>
        /// <returns></returns>
        [HttpGet("getmodalities", Name = nameof(GetModalities))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ModalityEnum>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<IEnumerable<ModalityEnum>> GetModalities()
        {
            var modalities = _modalityService.GetModalities();
            return Ok(new ApiResponse<IEnumerable<string>>(modalities));
        }

        /// <summary>
        /// Get Modality By Name
        /// </summary>
        /// <param name="modalityName"></param>
        /// <returns></returns>
        [HttpGet("modality")]
        public IActionResult GetModalityByName(string modalityName)
        {
            try
            {
                var modality = _modalityService.GetModality(modalityName);
                return Ok(new ApiResponse<ModalityEnum>(modality));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }
    }
}
