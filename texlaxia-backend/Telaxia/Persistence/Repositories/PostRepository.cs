using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class PostRepository:BaseRepository,IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task<Post> FindByIdAsync(int id)
    {
        return await _context.Posts.FindAsync(id);
    }

    public void Update(Post post)
    {
        _context.Posts.Update(post);
    }

    public void Remove(Post post)
    {
        _context.Posts.Remove(post);
    }
}