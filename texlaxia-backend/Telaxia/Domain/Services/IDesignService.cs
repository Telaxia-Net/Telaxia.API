using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IDesignService
{
    Task<IEnumerable<Design>> ListAsync();
    Task<DesignResponse> SaveAsync(Design designCollaborator);
    Task<DesignResponse> UpdateAsync(int id, Design designCollaborator);
    Task<DesignResponse> DeleteAsync(int id);
}