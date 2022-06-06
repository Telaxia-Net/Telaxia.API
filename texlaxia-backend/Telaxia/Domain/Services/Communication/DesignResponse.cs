using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class DesignResponse:BaseResponse<Design>
    {
        public DesignResponse(Design resource) : base(resource)
        {
        }

        public DesignResponse(string message) : base(message)
        {
        }
    }
}