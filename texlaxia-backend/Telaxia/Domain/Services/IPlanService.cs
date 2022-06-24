using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IPlanService
{
    Task<IEnumerable<Plan>> ListAsync();
    Task<PlanResponse> SaveAsync(Plan plan);
    Task<PlanResponse> UpdateAsync(int id, Plan plan);
    Task<PlanResponse> DeleteAsync(int id);
}