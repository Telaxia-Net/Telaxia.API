using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class CooperativeResponse:BaseResponse<Cooperative>
    {
        public CooperativeResponse(Cooperative resource) : base(resource)
        {
        }

        public CooperativeResponse(string message) : base(message)
        {
        }
    }
}