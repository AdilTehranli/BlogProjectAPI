using BlogProject.Business.Dtos.BlogDtos;
using BlogProject.Business.Dtos.CommentDtos;
using BlogProject.Business.Services.Implements;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
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
        readonly ICommentService _commentService;
        public BlogsController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
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
        [HttpPost("{id}")]
        public async Task<IActionResult> CommentCreate(int id,CommentCreateDto dto)
        {
            await _commentService.CreateAsync(id,dto);
            return Ok();
        }
        [HttpPost("[action]{id}")]
        public async Task<IActionResult> React(int id,Reactions reactions)
        {
            await _blogService.ReactAsync(id, reactions);
            return Ok();
        }
        [HttpDelete("[action]{id}")]
        public async Task<IActionResult> ReactRemove(int id)
        {
            await _blogService.RemoveReactAsync(id);
            return Ok();
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
