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
    [Route("api/[controller]")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private readonly IFighterService _fighterService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public FighterController(IFighterService fighterService, IMapper mapper, IUriService uriService)
        {
            _fighterService = fighterService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Get Fighters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetFighters))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<FighterDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetFighters([FromQuery] FighterQueryFilter filters)
        {
            var fighters = _fighterService.GetFighters(filters);
            var fightersDtos = _mapper.Map<IEnumerable<FighterDto>>(fighters);

            var metadata = new Metadata
            {
                TotalCount = fighters.TotalCount,
                PageSize = fighters.PageSize,
                CurrentPage = fighters.CurrentPage,
                TotalPages = fighters.TotalPages,
                HasNextPage = fighters.HasNextPage,
                HasPreviousPage = fighters.HasPreviousPage,
                NextPageUrl = _uriService.GetFighterPaginationUri(filters, Url.RouteUrl(nameof(GetFighters))).ToString(),
                PreviousPageUrl = _uriService.GetFighterPaginationUri(filters, Url.RouteUrl(nameof(GetFighters))).ToString()
            };

            var response = new ApiResponse<IEnumerable<FighterDto>>(fightersDtos)
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
        /// Get Fighter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fighter = await _fighterService.GetFighter(id);
            var fighterDto = _mapper.Map<FighterDto>(fighter);
            var response = new ApiResponse<FighterDto>(fighterDto);
            return Ok(response);
        }

        /// <summary>
        /// InsertFighter
        /// </summary>
        /// <param name="fighterDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(FighterDto fighterDto)
        {
            var fighter = _mapper.Map<Fighter>(fighterDto);

            await _fighterService.InsertFighter(fighter);

            fighterDto = _mapper.Map<FighterDto>(fighter);
            var response = new ApiResponse<FighterDto>(fighterDto);

            return Ok(response);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fighterDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FighterDto fighterDto)
        {
            try
            {
                var fighter = _mapper.Map<Fighter>(fighterDto);
                fighter.Id = id;

                await _fighterService.UpdateFighter(fighter);

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
            var result = await _fighterService.DeleteFighter(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
