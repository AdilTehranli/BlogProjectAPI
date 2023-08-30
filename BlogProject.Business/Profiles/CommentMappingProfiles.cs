using AutoMapper;
using BlogProject.Business.Dtos.CommentDtos;
using BlogProject.Core.Entities;

namespace BlogProject.Business.Profiles;

public class CommentMappingProfiles:Profile
{
    public CommentMappingProfiles()
    {
        CreateMap<Comment, CommentDetailDto>();
        CreateMap<Comment, CommentListItemDto>();
        CreateMap<CommentCreateDto, Comment>();
        CreateMap<CommentChildrenDto, Comment>().ReverseMap();
    }
}
