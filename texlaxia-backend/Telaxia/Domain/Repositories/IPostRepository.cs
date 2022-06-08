using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> ListAsync();
    Task AddAsync(Post post);
    Task<Post> FindByIdAsync(int id);
    void Update(Post post);
    void Remove(Post post);
}