using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Repositories;

public interface IDesignCollaboratorRepository
{
    Task<IEnumerable<DesignCollaborator>> ListAsync();
    Task AddAsync(DesignCollaborator designCollaborator);
    Task<DesignCollaborator> FindByIdAsync(int id);
    void Update(DesignCollaborator designCollaborator);
    void Remove(DesignCollaborator designCollaborator);
}