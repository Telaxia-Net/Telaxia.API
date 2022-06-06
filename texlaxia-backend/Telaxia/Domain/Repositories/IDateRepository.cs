using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface IDateRepository
    {
        Task<IEnumerable<Date>> ListAsync();
        Task AddAsync(Date date);
        Task<Date> FindById(int id);
        void Remove(Date date);
        void Update(Date date);
    }
}