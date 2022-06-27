
using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

using System.Threading.Tasks;

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

    public async Task<IEnumerable<Comment>> ListAsync()
    {
        return await _commentRepository.ListAsync();
    }

    public async Task<IEnumerable<Comment>> ListByCategoryIdAsync(int commentId)
    {
        return await _commentRepository.FindByCommentIdAsync(commentId);
    }

    public async Task<CommentResponse> SaveAsync(Comment comment)
    {
        try
        {
            await _commentRepository.AddAsync(comment);
            await _unitOfWork.CompleteAsync();

            return new CommentResponse(comment);
        }
        catch (Exception e)
        {
            return new CommentResponse($"An error occurred while saving the Comment: {e.Message}");
        }
    }

    public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
    {
        var existingComment = await _commentRepository.FindByIdAsync(id);

        if (existingComment == null)
            return new CommentResponse("Comment not found.");

        existingComment.body = comment.body;
        existingComment.date = comment.date;
        
        try
        {
            _commentRepository.Update(existingComment);
            await _unitOfWork.CompleteAsync();
            
            return new CommentResponse(existingComment);
        }
        catch (Exception e)
        {
            return new CommentResponse($"An error occurred while updating the Comment: {e.Message}");
        }
    }

    public async Task<CommentResponse> DeleteAsync(int id)
    {
        var existingComment = await _commentRepository.FindByIdAsync(id);

        if (existingComment == null)
            return new CommentResponse("Comment not found.");

        try
        {
            _commentRepository.Remove(existingComment);
            await _unitOfWork.CompleteAsync();

            return new CommentResponse(existingComment);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CommentResponse($"An error occurred while deleting the Comment: {e.Message}");
        }
    }

    public async Task<IEnumerable<Comment>> ListByCommentContain(string word)
    {
        var existingComments = await _commentRepository.FindByCommentContent(word);
        return existingComments;
    }
}