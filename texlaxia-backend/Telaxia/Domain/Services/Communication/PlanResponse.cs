using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication;
public class PlanResponse:BaseResponse<Plan>
{
    public PlanResponse(Plan resource) : base(resource)
    {
    }
    public PlanResponse(string message) : base(message)
    {
    }
}
