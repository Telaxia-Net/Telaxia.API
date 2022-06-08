using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IDesignCollaboratorService
{
    Task<IEnumerable<DesignCollaboratorResponse>> ListAsync();
    Task<DesignCollaboratorResponse> SaveAsync(DesignCollaborator designCollaborator);
    Task<DesignCollaboratorResponse> UpdateAsync(int id, DesignCollaborator designCollaborator);
    Task<DesignCollaboratorResponse> DeleteAsync(int id);
}