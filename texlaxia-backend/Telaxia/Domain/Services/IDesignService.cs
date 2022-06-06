using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services;

    public interface IDesignService
    {
        Task<IEnumerable<Design>> ListAsync();
        Task<DesignResponse> SaveAsync(Design design);
        Task<DesignResponse> UpdateAsync(int id, Design design);
        Task<DesignResponse> DeleteAsync(int id);
    }
