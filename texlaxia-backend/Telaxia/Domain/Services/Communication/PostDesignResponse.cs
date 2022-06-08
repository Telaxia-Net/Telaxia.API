using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class PostDesignResponse: BaseResponse<PostDesign>
{
    public PostDesignResponse(PostDesign resource) : base(resource)
    {
    }

    public PostDesignResponse(string message) : base(message)
    {
    }
}