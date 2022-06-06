using System.Collections;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Telaxia_Backend.Shared.Extensions;
using Telaxia_Backend.Telaxia.Domain.Services;
using Telaxia_Backend.Telaxia.Resources;

namespace Telaxia_Backend.Controllers;

[Route("/api/v1/[controller]")]
public class CooperativeController:ControllerBase
{
    private readonly ICooperativeService _cooperativeService;
    private readonly IMapper _mapper;


    public CooperativeController(ICooperativeService cooperativeService, IMapper mapper)
    {
        _cooperativeService = cooperativeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CooperativeResource>> GetAllAsync()
    {
        var cooperative = await _cooperativeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Cooperative>, IEnumerable<CooperativeResource>>(cooperative);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCooperativeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cooperative = _mapper.Map<SaveCooperativeResource, Cooperative>(resource);

        var result = await _cooperativeService.SaveAsync(cooperative);

        if (!result.Success)
            return BadRequest(result.Message);

        var cooperativeResource = _mapper.Map<Cooperative, CooperativeResource>(result.Resource);

        return Ok(cooperativeResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCooperativeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cooperative = _mapper.Map<SaveCooperativeResource, Cooperative>(resource);

        var result = await _cooperativeService.UpdateAsync(id, cooperative);

        if (!result.Success)
            return BadRequest(result.Message);

        var cooperativeResource = _mapper.Map<Cooperative, CooperativeResource>(result.Resource);

        return Ok(cooperativeResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cooperativeService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var cooperativeResource = _mapper.Map<Cooperative, CooperativeResource>(result.Resource);

        return Ok(cooperativeResource);
    }
}