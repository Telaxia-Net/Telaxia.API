using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class PlanService:IPlanService
{
    private readonly IPlanRepository _planRepository;

    private readonly IUnitOfWork _unitOfWork;

    public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Plan>> ListAsync()
    {
        return await _planRepository.ListAsync();
    }

    public async Task<PlanResponse> SaveAsync(Plan plan)
    {
        try
        {
            await _planRepository.AddAsync(plan);
            await _unitOfWork.CompleteAsync();

            return new PlanResponse(plan);
        }
        catch (Exception e)
        {
            return new PlanResponse($"An error occurred while saving the Plan: {e.Message}");
        }
    }

    public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
    {
        var existingPlan = await _planRepository.FindByIdAsync(id);

        if (existingPlan == null)
            return new PlanResponse("Plan not found.");

        existingPlan.Name = plan.Name;
        existingPlan.Description = plan.Description;
        existingPlan.Price = plan.Price;

        try
        {
            _planRepository.Update(existingPlan);
            await _unitOfWork.CompleteAsync();
            
            return new PlanResponse(existingPlan);
        }
        catch (Exception e)
        {
            return new PlanResponse($"An error occurred while updating the Plan: {e.Message}");
        }
    }
    public async Task<PlanResponse> DeleteAsync(int id)
    {
        var existingPlan = await _planRepository.FindByIdAsync(id);

        if (existingPlan == null)
            return new PlanResponse("Plan not found.");

        try
        {
            _planRepository.Remove(existingPlan);
            await _unitOfWork.CompleteAsync();

            return new PlanResponse(existingPlan);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PlanResponse($"An error occurred while deleting the User: {e.Message}");
        }
    }
}