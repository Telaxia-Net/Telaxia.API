using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponse>> ListAsync();
    Task<UserResponse> SaveAsync(User designCollaborator);
    Task<UserResponse> UpdateAsync(int id, User designCollaborator);
    Task<UserResponse> DeleteAsync(int id);
}