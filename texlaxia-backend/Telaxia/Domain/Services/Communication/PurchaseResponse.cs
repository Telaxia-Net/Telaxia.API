using texlaxia_backend.Shared.Domain.Services.Communication;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Domain.Services.Communication;

public class PurchaseResponse: BaseResponse<Purchase>
{
    public PurchaseResponse(Purchase resource) : base(resource)
    {
    }

    public PurchaseResponse(string message) : base(message)
    {
    }
}