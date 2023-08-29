using BlogProject.Business.Dtos.BlogDtos;
using BlogProject.Business.Services.Implements;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        readonly IBlogService _blogService;
public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _blogService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _blogService.GetByIdAsync(id));
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
        [HttpPost]

        public async Task<IActionResult> Post(BlogCreateDto dto)
        {
            try
            {
                await _blogService.CreateAsync(dto);
                return Ok(); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
