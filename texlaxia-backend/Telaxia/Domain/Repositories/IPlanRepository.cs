using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task AddAsync(Plan plan);
        Task<Plan> FindById(int id);
        void Remove(Plan plan);
        void Update(Plan plan);
    }
}