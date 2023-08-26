using AutoMapper;
using BlogProject.Business.Dtos.UserDtos;
using BlogProject.Business.Exceptions.User;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BlogProject.Business.Services.Implements;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task Register(RegisterDto dto)
    {
      var user = _mapper.Map<AppUser>(dto);
        if(await _userManager.Users.AnyAsync(u=>dto.UserName == user.UserName || dto.Email == u.Email ))
            throw new UserExistException();
        var result =   await _userManager.CreateAsync(user,dto.Password);
        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }
            throw new UserFailedException(sb.ToString().TrimEnd());
        }
        
    }
}
