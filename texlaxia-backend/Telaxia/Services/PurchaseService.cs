using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class PurchaseService:IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;

    private readonly IUnitOfWork _unitOfWork;

    public PurchaseService(IPurchaseRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _purchaseRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Purchase>> ListAsync()
    {
        return await _purchaseRepository.ListAsync();
    }

    public async Task<PurchaseResponse> SaveAsync(Purchase purchase)
    {
        try
        {
            await _purchaseRepository.AddAsync(purchase);
            await _unitOfWork.CompleteAsync();

            return new PurchaseResponse(purchase);
        }
        catch (Exception e)
        {
            return new PurchaseResponse($"An error occurred while saving the Purchase: {e.Message}");
        }
    }
    
}