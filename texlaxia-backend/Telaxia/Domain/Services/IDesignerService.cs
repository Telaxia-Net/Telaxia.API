using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IDesignerService
{
    Task<IEnumerable<Designer>> ListAsync();
    Task<DesignerResponse> SaveAsync(Designer designer);
    Task<DesignerResponse> DeleteAsync(int id);
}