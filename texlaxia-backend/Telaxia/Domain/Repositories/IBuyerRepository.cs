using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IBuyerRepository
{
    Task<IEnumerable<Buyer>> ListAsync();
    Task AddAsync(Buyer buyer);
    Task<Buyer> FindByIdAsync(int id);
    void Update(Buyer buyer);
    void Remove(Buyer buyer);
}