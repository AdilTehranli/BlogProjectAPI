﻿using BlogProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _roleService.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(string id)
        {
            return Ok(await _roleService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {
            await _roleService.CreateAsync(name);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _roleService.RemoveAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(string id,string name)
        {
            await _roleService.UpdateAsync(id,name);
            return Ok();
        }
    }
}
