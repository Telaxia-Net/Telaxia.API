using Telaxia_Backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IPostDesignRepository
{
    Task<IEnumerable<PostDesign>> ListAsync();
    Task AddAsync(PostDesign postDesign);
    Task<PostDesign> FindByIdAsync(int id);
    void Update(PostDesign postDesign);
    void Remove(PostDesign postDesign);
}