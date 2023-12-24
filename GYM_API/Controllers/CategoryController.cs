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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcategories", Name = nameof(GetCategories))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CategoryEnum>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<IEnumerable<CategoryEnum>> GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(new ApiResponse<IEnumerable<string>>(categories));
        }
        
        /// <summary>
        /// Get Category By Name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpGet("category")]
        public IActionResult GetCategoryByName(string categoryName)
        {
            try
            {
                var category = _categoryService.GetCategory(categoryName);
                return Ok(new ApiResponse<CategoryEnum>(category));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }
    }
}
