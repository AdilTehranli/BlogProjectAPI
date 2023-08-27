using BlogProject.Business.Dtos.UserRoleDtos;
using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRoleService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoleCreateDto dto)
        {
            await _userRoleService.CreateAsync(dto);
            return NoContent();
        }
    }
}
