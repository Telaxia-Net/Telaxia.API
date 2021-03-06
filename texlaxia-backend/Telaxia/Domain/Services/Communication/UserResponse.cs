using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class UserResponse: BaseResponse<User>
{
    public UserResponse(User resource) : base(resource)
    {
    }

    public UserResponse(string message) : base(message)
    {
    }
}