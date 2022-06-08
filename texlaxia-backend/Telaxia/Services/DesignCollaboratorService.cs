using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class DesignCollaboratorService : IDesignCollaboratorService
{
    private readonly IDesignCollaboratorRepository _designCollaboratorRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DesignCollaboratorService(IDesignCollaboratorRepository designCollaboratorRepository, IUnitOfWork unitOfWork)
    {
        _designCollaboratorRepository = designCollaboratorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DesignCollaborator>> ListAsync()
    {
        return await _designCollaboratorRepository.ListAsync();
    }

    public async Task<DesignCollaboratorResponse> SaveAsync(DesignCollaborator designCollaborator)
    {
        try
        {
            await _designCollaboratorRepository.AddAsync(designCollaborator);
            await _unitOfWork.CompleteAsync();

            return new DesignCollaboratorResponse(designCollaborator);
        }
        catch (Exception e)
        {
            return new DesignCollaboratorResponse($"An error occurred while saving the DesignCollaborator: {e.Message}");
        }
    }

    public async Task<DesignCollaboratorResponse> UpdateAsync(int id, DesignCollaborator designCollaborator)
    {
        var existingDesignCollaborator = await _designCollaboratorRepository.FindByIdAsync(id);

        if (existingDesignCollaborator == null)
            return new DesignCollaboratorResponse("DesignCollaborator not found.");

        existingDesignCollaborator.Name = designCollaborator.Name;
        existingDesignCollaborator.Description = designCollaborator.Description;

        try
        {
            _designCollaboratorRepository.Update(existingDesignCollaborator);
            await _unitOfWork.CompleteAsync();
            
            return new DesignCollaboratorResponse(existingDesignCollaborator);
        }
        catch (Exception e)
        {
            return new DesignCollaboratorResponse($"An error occurred while updating the DesignCollaborator: {e.Message}");
        }
    }
    

    public async Task<DesignCollaboratorResponse> DeleteAsync(int id)
    {
        var existingDesignCollaborator = await _designCollaboratorRepository.FindByIdAsync(id);

        if (existingDesignCollaborator == null)
            return new DesignCollaboratorResponse("DesignCollaborator not found.");

        try
        {
            _designCollaboratorRepository.Remove(existingDesignCollaborator);
            await _unitOfWork.CompleteAsync();

            return new DesignCollaboratorResponse(existingDesignCollaborator);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new DesignCollaboratorResponse($"An error occurred while deleting the DesignCollaborator: {e.Message}");
        }
    }
}