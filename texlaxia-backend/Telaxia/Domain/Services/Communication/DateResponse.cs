using Telaxia_Backend.Shared.Domain.Services.Communication;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Domain.Services.Communication
{
    public class DateResponse:BaseResponse<Date>
    {
        public DateResponse(Date resource) : base(resource)
        {
        }

        public DateResponse(string message) : base(message)
        {
        }
    }
}