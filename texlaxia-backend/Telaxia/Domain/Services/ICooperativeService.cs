using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services;

    public interface ICooperativeService
    {
        Task<IEnumerable<Cooperative>> ListAsync();
        Task<CooperativeResponse> SaveAsync(Cooperative cooperative);
        Task<CooperativeResponse> UpdateAsync(int id, Cooperative cooperative);
        Task<CooperativeResponse> DeleteAsync(int id);
    }
