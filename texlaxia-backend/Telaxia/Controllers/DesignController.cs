using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Telaxia_Backend.Shared.Extensions;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services;
using Telaxia_Backend.Telaxia.Resources;

namespace Telaxia_Backend.Controllers;
[Route("/api/v1/[controller]")]
public class DesignController:ControllerBase
{
    private readonly IDesignService _designService;
    private readonly IMapper _mapper;


    public DesignController(IDesignService designService, IMapper mapper)
    {
        _designService = designService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DesignsResource>> GetAllAsync()
    {
        var design = await _designService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Design>, IEnumerable<DesignsResource>>(design);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDesignsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var design = _mapper.Map<SaveDesignsResource, Design>(resource);

        var result = await _designService.SaveAsync(design);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignsResource>(result.Resource);

        return Ok(designResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDesignsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var design = _mapper.Map<SaveDesignsResource, Design>(resource);

        var result = await _designService.UpdateAsync(id, design);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignsResource>(result.Resource);

        return Ok(designResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _designService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var designResource = _mapper.Map<Design, DesignsResource>(result.Resource);

        return Ok(designResource);
    }
}