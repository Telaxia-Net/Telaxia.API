using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class BuyersController:ControllerBase
{
    private readonly IBuyerService _buyerService;
    private readonly IMapper _mapper;
    
    
    public BuyersController(IBuyerService BuyerService, IMapper mapper)
    {
        _buyerService = BuyerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BuyerResource>> GetAllAsync()
    {
        var buyers = await _buyerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Buyer>, IEnumerable<BuyerResource>>(buyers);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBuyerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var buyer = _mapper.Map<SaveBuyerResource, Buyer>(resource);

        var result = await _buyerService.SaveAsync(buyer);

        if (!result.Success)
            return BadRequest(result.Message);

        var buyerResource = _mapper.Map<Buyer, BuyerResource>(result.Resource);

        return Ok(buyerResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _buyerService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var buyerResource = _mapper.Map<Buyer, BuyerResource>(result.Resource);

        return Ok(buyerResource);
    }
}