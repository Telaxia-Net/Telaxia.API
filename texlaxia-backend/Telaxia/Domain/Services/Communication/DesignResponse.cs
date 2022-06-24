using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class DesignResponse: BaseResponse<Design>
{
    public DesignResponse(Design resource) : base(resource)
    {
    }

    public DesignResponse(string message) : base(message)
    {
    }
}