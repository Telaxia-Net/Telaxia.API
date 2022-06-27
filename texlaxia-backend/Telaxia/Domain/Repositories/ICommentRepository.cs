using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> ListAsync();
    Task AddAsync(Comment comment);
    Task<Comment> FindByIdAsync(int id);
    Task<IEnumerable<Comment>> FindByCommentIdAsync(int id);

    Task<IEnumerable<Comment>> FindByCommentContent(string word);
    void Update(Comment comment);
    void Remove(Comment comment);
}