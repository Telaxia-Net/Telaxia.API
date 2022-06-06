using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services
{
    public interface IDateService
    {
        Task<IEnumerable<Date>> ListAsync();
        Task<DateResponse> SaveAsync(Date date);
        Task<DateResponse> UpdateAsync(int id, Date date);
        Task<DateResponse> DeleteAsync(int id);
    }
}