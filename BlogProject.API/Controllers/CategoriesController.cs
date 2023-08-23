using BlogProject.Business.Dtos.CategoryDtos;
using BlogProject.Business.Exceptions.Category;
using BlogProject.Business.Exceptions.Commons;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               return Ok( await _categoryService.GetByIdAsync(id));
            }
            catch (NegativeIdException ex)
            {

                return BadRequest(new { ex.Message });
            }
            catch (CategoryException ex)
            {
                return NotFound(new { ex.Message });
            }  
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }   
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CategoryCreateDto dto)
        {
            await _categoryService.CreateAsync(dto);
            return NoContent();
        }
    }
}
