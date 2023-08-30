using AutoMapper;
using BlogProject.Business.Dtos.CommentDtos;
using BlogProject.Business.Exceptions.Commons;
using BlogProject.Business.Services.Interfaces;
using BlogProject.Core.Entities;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogProject.Business.Services.Implements;

public class CommentService : ICommentService
{
    readonly IBlogRepository _blogRepository;
    readonly ICommentRepository _commentRepository;
    readonly string _userId;
    readonly IHttpContextAccessor _httpContextAccessor;
    readonly IMapper _mapper;
    readonly UserManager<AppUser> _userManager;

    public CommentService(IBlogRepository blogRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, ICommentRepository commentRepository)
    {
        _blogRepository = blogRepository;
        _httpContextAccessor = httpContextAccessor;
        _userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        _mapper = mapper;
        _userManager = userManager;
        _commentRepository = commentRepository;
    }

    public async Task CreateAsync(int id, CommentCreateDto dto)
    {

        if (string.IsNullOrWhiteSpace(_userId)) throw new ArgumentNullException();
        if (!await _userManager.Users.AnyAsync(u => u.Id == _userId)) throw new ArgumentException();
        if (id <= 0) throw new NegativeIdException();
        if (await _blogRepository.IsExistAsync(b => b.Id == id)) throw new NotFoundException<Comment>();
        var comment = _mapper.Map<Comment>(dto);
        comment.AppUserId= _userId;
        comment.BlogId = id;
        await _commentRepository.CreateAsync(comment);
        await _commentRepository.SaveAsync();

       
    }

    public Task<IEnumerable<CommentListItemDto>> GetAllAsync(int id)
    {
        throw new NotImplementedException();
    }
}
