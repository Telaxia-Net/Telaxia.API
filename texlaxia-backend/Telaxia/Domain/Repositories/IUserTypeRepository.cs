using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> ListAsync();
        Task AddAsync(UserType userType);
        Task<UserType> FindById(int id);
        void Remove(UserType userType);
        void Update(UserType userType);
    }
}