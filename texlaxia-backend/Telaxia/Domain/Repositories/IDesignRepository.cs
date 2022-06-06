using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface IDesignRepository
    {
        Task<IEnumerable<Design>> ListAsync();
        Task AddAsync(Design design);
        Task<Design> FindById(int id);
        void Remove(Design design);
        void Update(Design design);
    }
}