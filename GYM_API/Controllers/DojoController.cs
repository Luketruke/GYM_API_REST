using AutoMapper;
using GYM.Api.Responses;
using GYM.Core.CustomEntities;
using GYM.Core.DTOs;
using GYM.Core.Entities;
using GYM.Core.Interfaces;
using GYM.Core.QueryFilters;
using GYM.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace GYM.Api.Controllers
{
    //[Authorize(Roles = nameof(Role.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DojoController : ControllerBase
    {
        private readonly IDojoService _dojoService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public DojoController(IDojoService dojoService, IMapper mapper, IUriService uriService)
        {
            _dojoService = dojoService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Get Dojos
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetAll))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DojoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetAll([FromQuery] DojoQueryFIlter filters)
        {
            var dojos = _dojoService.GetDojos(filters);
            var dojosDtos = _mapper.Map<IEnumerable<DojoDto>>(dojos);

            var metadata = new Metadata
            {
                TotalCount = dojos.TotalCount,
                PageSize = dojos.PageSize,
                CurrentPage = dojos.CurrentPage,
                TotalPages = dojos.TotalPages,
                HasNextPage = dojos.HasNextPage,
                HasPreviousPage = dojos.HasPreviousPage,
                NextPageUrl = _uriService.GetDojoPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = _uriService.GetDojoPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<DojoDto>>(dojosDtos)
            {
                meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Get Dojo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dojo = await _dojoService.GetDojo(id);
            var dojoDto = _mapper.Map<DojoDto>(dojo);
            var response = new ApiResponse<DojoDto>(dojoDto);
            return Ok(response);
        }

        /// <summary>
        /// InsertDojo
        /// </summary>
        /// <param name="dojoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(DojoDto dojoDto)
        {
            var dojo = _mapper.Map<Dojo>(dojoDto);

            await _dojoService.InsertDojo(dojo);

            dojoDto = _mapper.Map<DojoDto>(dojo);
            var response = new ApiResponse<DojoDto>(dojoDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DojoDto dojoDto)
        {
            try
            {
                var dojo = _mapper.Map<Dojo>(dojoDto);
                dojo.Id = id;

                await _dojoService.UpdateDojo(dojo);

                var response = new ApiResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _dojoService.DeleteDojo(id);
            //var response = new ApiResponse<bool>(result);
            return Ok(result);
        }
    }
}
