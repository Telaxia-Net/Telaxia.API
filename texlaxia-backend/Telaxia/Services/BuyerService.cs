using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class BuyerService:IBuyerService
{
    private readonly IBuyerRepository _buyerRepository;

    private readonly IUnitOfWork _unitOfWork;

    public BuyerService(IBuyerRepository buyerRepository, IUnitOfWork unitOfWork)
    {
        _buyerRepository = buyerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Buyer>> ListAsync()
    {
        return await _buyerRepository.ListAsync();
    }

    public async Task<BuyerResponse> SaveAsync(Buyer buyer)
    {
        try
        {
            await _buyerRepository.AddAsync(buyer);
            await _unitOfWork.CompleteAsync();

            return new BuyerResponse(buyer);
        }
        catch (Exception e)
        {
            return new BuyerResponse($"An error occurred while saving the Buyer: {e.Message}");
        }
    }
    
    public async Task<BuyerResponse> DeleteAsync(int id)
    {
        var existingBuyer = await _buyerRepository.FindByIdAsync(id);

        if (existingBuyer == null)
            return new BuyerResponse("Buyer not found.");

        try
        {
            _buyerRepository.Remove(existingBuyer);
            await _unitOfWork.CompleteAsync();

            return new BuyerResponse(existingBuyer);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new BuyerResponse($"An error occurred while deleting the Buyer: {e.Message}");
        }
    }
}