using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class CommentResponse : BaseResponse<Comment>
{
    public CommentResponse(Comment resource) : base(resource)
    {
    }

    public CommentResponse(string message) : base(message)
    {
    }
}