using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task AddAsync(Profile profile);
        Task<Profile> FindById(int id);
        void Remove(Profile profile);
        void Update(Profile profile);
    }
}