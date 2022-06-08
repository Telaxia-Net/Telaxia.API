using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class DesignCollaboratorsController:ControllerBase
{
    private readonly IDesignCollaboratorService _designCollaboratorService;
    private readonly IMapper _mapper;


    public DesignCollaboratorsController(IDesignCollaboratorService designCollaboratorService, IMapper mapper)
    {
        _designCollaboratorService = designCollaboratorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DesignCollaboratorResource>> GetAllAsync()
    {
        var designCollaborators = await _designCollaboratorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<DesignCollaborator>, IEnumerable<DesignCollaboratorResource>>(designCollaborators);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDesignCollaboratorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var designCollaborator = _mapper.Map<SaveDesignCollaboratorResource, DesignCollaborator>(resource);

        var result = await _designCollaboratorService.SaveAsync(designCollaborator);

        if (!result.Success)
            return BadRequest(result.Message);

        var designCollaboratorResource = _mapper.Map<DesignCollaborator, DesignCollaboratorResource>(result.Resource);

        return Ok(designCollaboratorResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDesignCollaboratorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var designCollaborator = _mapper.Map<SaveDesignCollaboratorResource, DesignCollaborator>(resource);

        var result = await _designCollaboratorService.UpdateAsync(id, designCollaborator);

        if (!result.Success)
            return BadRequest(result.Message);

        var designCollaboratorResource = _mapper.Map<DesignCollaborator, DesignCollaboratorResource>(result.Resource);

        return Ok(designCollaboratorResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _designCollaboratorService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var designCollaboratorResource = _mapper.Map<DesignCollaborator, DesignCollaboratorResource>(result.Resource);

        return Ok(designCollaboratorResource);
    }
}