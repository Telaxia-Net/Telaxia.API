using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class DesignsController:ControllerBase
{
    private readonly IDesignService _designService;
    private readonly IMapper _mapper;


    public DesignsController(IDesignService DesignService, IMapper mapper)
    {
        _designService = DesignService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DesignResource>> GetAllAsync()
    {
        var designs = await _designService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Design>, IEnumerable<DesignResource>>(designs);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDesignResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var design = _mapper.Map<SaveDesignResource, Design>(resource);

        var result = await _designService.SaveAsync(design);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignResource>(result.Resource);

        return Ok(designResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsyncData(int id, [FromBody] SaveDesignResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var design = _mapper.Map<SaveDesignResource, Design>(resource);

        var result = await _designService.UpdateAsync(id, design);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignResource>(result.Resource);

        return Ok(designResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _designService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignResource>(result.Resource);

        return Ok(designResource);
    }
}