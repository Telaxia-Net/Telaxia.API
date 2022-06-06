using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task<ProfileResponse> SaveAsync(Profile profile);
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}