using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IDesignerRepository
{
    Task<IEnumerable<Designer>> ListAsync();
    Task AddAsync(Designer designer);
    Task<Designer> FindByIdAsync(int id);
    void Update(Designer designer);
    void Remove(Designer designer);
}