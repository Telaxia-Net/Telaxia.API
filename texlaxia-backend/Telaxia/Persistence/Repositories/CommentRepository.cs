using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class CommentRepository:BaseRepository, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> ListAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
    }

    public async Task<Comment> FindByIdAsync(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<IEnumerable<Comment>> FindByCommentIdAsync(int postId)
    {
        //throw new NotImplementedException(); 
        return await _context.Comments
            .Where(p=>p.PostId == postId)
            .Include(p=>p.Post)
            .ToListAsync();
    }

    public void Update(Comment comment)
    {
        _context.Comments.Update(comment);
    }

    public void Remove(Comment comment)
    {
        _context.Comments.Remove(comment);
    }
}