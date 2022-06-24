using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class DesignerResponse: BaseResponse<Designer>
{
    public DesignerResponse(Designer resource) : base(resource)
    {
    }

    public DesignerResponse(string message) : base(message)
    {
    }
}