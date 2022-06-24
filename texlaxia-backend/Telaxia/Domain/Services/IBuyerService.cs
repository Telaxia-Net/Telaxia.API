using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IBuyerService
{
    Task<IEnumerable<Buyer>> ListAsync();
    Task<BuyerResponse> SaveAsync(Buyer buyer);
    Task<BuyerResponse> DeleteAsync(int id);
}