using AutoMapper;
using BlogProject.Business.Dtos.UserDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Profiles;

public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        CreateMap<RegisterDto, AppUser>();
    }
}

