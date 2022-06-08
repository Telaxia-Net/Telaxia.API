using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/posts/{postId}/comments")]
public class PostCommentsController:ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;
    public PostCommentsController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<CommentResource>> GetAllByPostIdAsync(int postId)
    {
        var comments = await _commentService.ListByCategoryIdAsync(postId);

        var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);

        return resources;
    }
}