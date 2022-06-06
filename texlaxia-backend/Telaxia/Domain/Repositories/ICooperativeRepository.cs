using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface ICooperativeRepository
    {
        Task<IEnumerable<Cooperative>> ListAsync();
        Task AddAsync(Cooperative user);
        Task<Cooperative> FindById(int designId,int userId);
        void Remove(Cooperative user);
        void Update(Cooperative user);
    }
}