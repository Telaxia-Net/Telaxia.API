using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IDesignRepository
{
    Task<IEnumerable<Design>> ListAsync();
    Task AddAsync(Design design);
    Task<Design> FindByIdAsync(int id);
    void Update(Design design);
    void Remove(Design design);
}