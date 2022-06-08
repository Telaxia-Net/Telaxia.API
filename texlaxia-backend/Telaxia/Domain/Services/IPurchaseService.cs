using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IPurchaseService
{
    Task<IEnumerable<Purchase>> ListAsync();
    Task<PurchaseResponse> SaveAsync(Purchase purchase);
    Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase);
}