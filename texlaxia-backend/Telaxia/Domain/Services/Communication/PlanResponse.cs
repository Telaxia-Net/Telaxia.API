using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class PlanResponse : BaseResponse<Plan>
{
    public PlanResponse(Plan resource) : base(resource)
    {
    }

    public PlanResponse(string message) : base(message)
    {
    }
}