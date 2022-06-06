using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class UserTypeResponse:BaseResponse<Post>
    {
        public UserTypeResponse(Post resource) : base(resource)
        {
        }

        public UserTypeResponse(string message) : base(message)
        {
        }
    }
}