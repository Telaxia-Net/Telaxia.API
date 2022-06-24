using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class DesignersController:ControllerBase
{
    private readonly IDesignerService _designerService;
    private readonly IMapper _mapper;


    public DesignersController(IDesignerService DesignerService, IMapper mapper)
    {
        _designerService = DesignerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DesignerResource>> GetAllAsync()
    {
        var designers = await _designerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Designer>, IEnumerable<DesignerResource>>(designers);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDesignerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var designer = _mapper.Map<SaveDesignerResource, Designer>(resource);

        var result = await _designerService.SaveAsync(designer);

        if (!result.Success)
            return BadRequest(result.Message);

        var designerResource = _mapper.Map<Designer, DesignerResource>(result.Resource);

        return Ok(designerResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _designerService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var designerResource = _mapper.Map<Designer, DesignerResource>(result.Resource);

        return Ok(designerResource);
    }
}