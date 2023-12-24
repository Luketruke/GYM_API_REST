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
        /// GetDojos
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetDojos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DojoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetDojos([FromQuery] DojoQueryFilter filters)
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
                NextPageUrl = _uriService.GetDojoPaginationUri(filters, Url.RouteUrl(nameof(GetDojos))).ToString(),
                PreviousPageUrl = _uriService.GetDojoPaginationUri(filters, Url.RouteUrl(nameof(GetDojos))).ToString()
            };

            var response = new ApiResponse<IEnumerable<DojoDto>>(dojosDtos)
            {
                meta = metadata
            };

            // Add the "x-pagination" header to the response
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            // Allow the browser to expose the "X-Pagination" header
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

            return Ok(response);
        }

        /// <summary>
        /// Get Dojos DDL
        /// </summary>
        /// <returns></returns>
        [HttpGet("getdojosddl", Name = nameof(GetDojosDDL))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DojoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public ActionResult<IEnumerable<DojoDto>> GetDojosDDL()
        {
            var dojos = _dojoService.GetDojosDDL();
            var dojosDto = _mapper.Map<IEnumerable<DojoDto>>(dojos);

            return Ok(new ApiResponse<IEnumerable<DojoDto>>(dojosDto));
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

            if (dojo != null)
            {
                var dojoDto = _mapper.Map<DojoDto>(dojo);
                var response = new ApiResponse<DojoDto>(dojoDto);
                return Ok(response);
            }
            else return NotFound();
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

            var result = await _dojoService.InsertDojo(dojo);

            if (result)
            {
                dojoDto = _mapper.Map<DojoDto>(dojo);
                var response = new ApiResponse<DojoDto>(dojoDto);
                return Ok(response);
            }
            else
            {
                var errorResponse = new ApiResponse<DojoDto>(new DojoDto
                {
                    Remarks = "Error inserting dojo"
                });
                return BadRequest(errorResponse);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dojoDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Logical Delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _dojoService.DeleteDojo(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
