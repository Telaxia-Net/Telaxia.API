using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class InformationResponse:BaseResponse<Information>
    {
        public InformationResponse(Information resource) : base(resource)
        {
        }

        public InformationResponse(string message) : base(message)
        {
        }
    }
}