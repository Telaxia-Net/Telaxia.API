using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class PostResponse:BaseResponse<Post>
    {
        public PostResponse(Post resource) : base(resource)
        {
        }

        public PostResponse(string message) : base(message)
        {
        }
    }
}