using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IPurchaseRepository
{
    Task<IEnumerable<Purchase>> ListAsync();
    Task AddAsync(Purchase purchase);
    Task<Purchase> FindByIdAsync(int id);
    void Update(Purchase purchase);
    void Remove(Purchase purchase);
}