using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> ListAsync();
        Task<UserTypeResponse> SaveAsync(UserType userType);
        Task<UserTypeResponse> UpdateAsync(int id, UserType userType);
        Task<UserTypeResponse> DeleteAsync(int id);
    }
}