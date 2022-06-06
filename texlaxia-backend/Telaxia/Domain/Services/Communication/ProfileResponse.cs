using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class ProfileResponse:BaseResponse<Profile>
    {
        public ProfileResponse(Profile resource) : base(resource)
        {
        }

        public ProfileResponse(string message) : base(message)
        {
        }
    }
}