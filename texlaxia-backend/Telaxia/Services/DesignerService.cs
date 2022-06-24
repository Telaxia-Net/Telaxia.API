using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class DesignerService:IDesignerService
{
    private readonly IDesignerRepository _designerRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DesignerService(IDesignerRepository designerRepository, IUnitOfWork unitOfWork)
    {
        _designerRepository = designerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Designer>> ListAsync()
    {
        return await _designerRepository.ListAsync();
    }

    public async Task<DesignerResponse> SaveAsync(Designer designer)
    {
        try
        {
            await _designerRepository.AddAsync(designer);
            await _unitOfWork.CompleteAsync();

            return new DesignerResponse(designer);
        }
        catch (Exception e)
        {
            return new DesignerResponse($"An error occurred while saving the Designer: {e.Message}");
        }
    }
    public async Task<DesignerResponse> DeleteAsync(int id)
    {
        var existingDesigner = await _designerRepository.FindByIdAsync(id);

        if (existingDesigner == null)
            return new DesignerResponse("Designer not found.");

        try
        {
            _designerRepository.Remove(existingDesigner);
            await _unitOfWork.CompleteAsync();

            return new DesignerResponse(existingDesigner);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new DesignerResponse($"An error occurred while deleting the Designer: {e.Message}");
        }
    }
}