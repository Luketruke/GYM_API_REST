using AutoMapper;
using GYM.Api.Responses;
using GYM.Core.DTOs;
using GYM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GYM.Api.Controllers
{
    //[Authorize(Roles = nameof(Role.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Provinces
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet("getprovinces", Name = nameof(GetProvinces))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProvinceDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public ActionResult<IEnumerable<ProvinceDto>> GetProvinces()
        { 
            var provinces = _addressService.GetProvinces();
            var provincesDtos = _mapper.Map<IEnumerable<ProvinceDto>>(provinces);

            return Ok(new ApiResponse<IEnumerable<ProvinceDto>>(provincesDtos));
        }

        /// <summary>
        /// Get All Localities
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet("getlocalities", Name = nameof(GetLocalities))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<LocalityDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public ActionResult<IEnumerable<LocalityDto>> GetLocalities()
        {
            var localities = _addressService.GetLocalities();
            var localitiesDtos = _mapper.Map<IEnumerable<LocalityDto>>(localities);

            return Ok(new ApiResponse<IEnumerable<LocalityDto>>(localitiesDtos));
        }

        /// <summary>
        /// Get Province By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("province/{id}")]
        public async Task<IActionResult> GetProvinceById(int id)
        {
            var province = await _addressService.GetProvince(id);
            var provinceDto = _mapper.Map<ProvinceDto>(province);
            var response = new ApiResponse<ProvinceDto>(provinceDto);
            return Ok(response);
        }

        /// <summary>
        /// Get Locality By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("locality/{id}")]
        public async Task<IActionResult> GetLocalityById(int id)
        {
            var locality = await _addressService.GetLocality(id);
            var localityDto = _mapper.Map<LocalityDto>(locality);
            var response = new ApiResponse<LocalityDto>(localityDto);
            return Ok(response);
        }
    }
}
