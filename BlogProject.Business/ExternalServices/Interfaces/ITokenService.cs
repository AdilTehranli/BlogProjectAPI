using BlogProject.Business.Dtos.UserDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.ExternalServices.Interfaces;

public interface ITokenService
{
    TokenResponceDto CreateToken(AppUser user, int expires = 60);
}
