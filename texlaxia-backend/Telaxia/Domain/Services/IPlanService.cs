using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> UpdateAsync(int id, Plan plan);
        Task<PlanResponse> DeleteAsync(int id);
    }
}