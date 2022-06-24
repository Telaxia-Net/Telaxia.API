using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class BuyerResponse: BaseResponse<Buyer>
{
    public BuyerResponse(Buyer resource) : base(resource)
    {
    }

    public BuyerResponse(string message) : base(message)
    {
    }
}