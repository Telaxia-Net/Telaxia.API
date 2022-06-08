using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class PostResponse: BaseResponse<Post>
{
    public PostResponse(Post resource) : base(resource)
    {
    }

    public PostResponse(string message) : base(message)
    {
    }
}