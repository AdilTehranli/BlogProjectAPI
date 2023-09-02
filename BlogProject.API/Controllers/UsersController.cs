using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public  async Task<IActionResult> Post(string role,string user)
        {
           await _userService.AddRoleAsync(role,user);
            return Ok();
        }
    }
}
