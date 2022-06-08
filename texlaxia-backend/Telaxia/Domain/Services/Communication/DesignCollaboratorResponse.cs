using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class DesignCollaboratorResponse: BaseResponse<DesignCollaborator>
{
    public DesignCollaboratorResponse(DesignCollaborator resource) : base(resource)
    {
    }

    public DesignCollaboratorResponse(string message) : base(message)
    {
    }
}