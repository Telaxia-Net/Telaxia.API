using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class CommentService: ICommentService
{
    private readonly ICommentRepository _commentRepository;
    
    private readonly IUnitOfWork _unitOfWork;
    
    public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public /*async*/ Task<IEnumerable<CommentResponse>> ListAsync()
    {
        //return await _commentRepository.ListAsync();
        throw new NotImplementedException();
    }

    public Task<CommentResponse> SaveAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<CommentResponse> UpdateAsync(int id, Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<CommentResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}