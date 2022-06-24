using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class DesignService:IDesignService
{
    private readonly IDesignRepository _designRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DesignService(IDesignRepository designRepository, IUnitOfWork unitOfWork)
    {
        _designRepository = designRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Design>> ListAsync()
    {
        return await _designRepository.ListAsync();
    }

    public async Task<DesignResponse> SaveAsync(Design design)
    {
        try
        {
            await _designRepository.AddAsync(design);
            await _unitOfWork.CompleteAsync();

            return new DesignResponse(design);
        }
        catch (Exception e)
        {
            return new DesignResponse($"An error occurred while saving the Design: {e.Message}");
        }
    }

    public async Task<DesignResponse> UpdateAsync(int id, Design design)
    {
        var existingDesign = await _designRepository.FindByIdAsync(id);

        if (existingDesign == null)
            return new DesignResponse("Design not found.");

        existingDesign.DesignViewUrl = design.DesignViewUrl;
        existingDesign.ImageDesign = design.ImageDesign;
        existingDesign.Visibility = design.Visibility;

        try
        {
            _designRepository.Update(existingDesign);
            await _unitOfWork.CompleteAsync();
            
            return new DesignResponse(existingDesign);
        }
        catch (Exception e)
        {
            return new DesignResponse($"An error occurred while updating the Design: {e.Message}");
        }
    }
    public async Task<DesignResponse> DeleteAsync(int id)
    {
        var existingDesign = await _designRepository.FindByIdAsync(id);

        if (existingDesign == null)
            return new DesignResponse("Design not found.");

        try
        {
            _designRepository.Remove(existingDesign);
            await _unitOfWork.CompleteAsync();

            return new DesignResponse(existingDesign);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new DesignResponse($"An error occurred while deleting the Design: {e.Message}");
        }
    }
}