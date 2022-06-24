using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class PlansController:ControllerBase
{
    private readonly IPlanService _planService;
    private readonly IMapper _mapper;

    public PlansController(IPlanService planService, IMapper mapper)
    {
        _planService = planService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PlanResource>> GetAllAsync()
    {
        var plans = await _planService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(plans);

        return resources;
    }

    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var plan = _mapper.Map<SavePlanResource, Plan>(resource);

        var result = await _planService.SaveAsync(plan);

        if (!result.Success)
            return BadRequest(result.Message);

        var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);

        return Ok(planResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var plan = _mapper.Map<SavePlanResource, Plan>(resource);

        var result = await _planService.UpdateAsync(id, plan);

        if (!result.Success)
            return BadRequest(result.Message);

        var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);

        return Ok(planResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _planService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);

        return Ok(planResource);
    }
}