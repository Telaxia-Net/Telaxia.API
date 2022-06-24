using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class BuyerRepository:BaseRepository,IBuyerRepository
{
    public BuyerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Buyer>> ListAsync()
    {
        return await _context.Buyers.ToListAsync();
    }

    public async Task AddAsync(Buyer buyer)
    {
        await _context.Buyers.AddAsync(buyer);
    }

    public async Task<Buyer> FindByIdAsync(int id)
    {
        return await _context.Buyers.FindAsync(id);
    }

    public void Update(Buyer buyer)
    {
        _context.Buyers.Update(buyer);
    }

    public void Remove(Buyer buyer)
    {
        _context.Buyers.Remove(buyer);
    }
}