using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>> ListAsync();
    Task<IEnumerable<Comment>> ListByCategoryIdAsync(int commentId);
    Task<IEnumerable<Comment>> ListByCommentContain(string word);
    Task<CommentResponse> SaveAsync(Comment comment);
    Task<CommentResponse> UpdateAsync(int id, Comment comment);
    Task<CommentResponse> DeleteAsync(int id);
}