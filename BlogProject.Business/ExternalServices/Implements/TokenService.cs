﻿using BlogProject.Business.Dtos.UserDtos;
using BlogProject.Business.ExternalServices.Interfaces;
using BlogProject.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogProject.Business.ExternalServices.Implements;

public class TokenService : ITokenService
{
    readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponceDto CreateToken(AppUser user, int expires = 60)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.Id)
    };
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
        SigningCredentials signing = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken jwtSecurity = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audiance"]
            , claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(60), signing);
        JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
        string token = securityTokenHandler.WriteToken(jwtSecurity);
        return new()
        {
            Token = token,
            Expires = jwtSecurity.ValidTo,
            UserName = user.UserName,
        };
    }
}