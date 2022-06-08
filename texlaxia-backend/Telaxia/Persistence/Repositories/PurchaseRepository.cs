using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Persistence.Contexts;

namespace texlaxia_backend.Telaxia.Persistence.Repositories;

public class PurchaseRepository:BaseRepository,IPurchaseRepository
{
    public PurchaseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Purchase>> ListAsync()
    {
        return await _context.Purchases.ToListAsync();
    }

    public async Task AddAsync(Purchase purchase)
    {
        await _context.Purchases.AddAsync(purchase);
    }

    public async Task<Purchase> FindByIdAsync(int id)
    {
        return await _context.Purchases.FindAsync(id);
    }

    public void Update(Purchase purchase)
    {
        _context.Purchases.Update(purchase);
    }

    public void Remove(Purchase purchase)
    {
        _context.Purchases.Remove(purchase);
    }
}