using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class PurchasesController:ControllerBase
{
    private readonly IPurchaseService _purchaseService;
    private readonly IMapper _mapper;


    public PurchasesController(IPurchaseService PurchaseService, IMapper mapper)
    {
        _purchaseService = PurchaseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PurchaseResource>> GetAllAsync()
    {
        var purchases = await _purchaseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePurchaseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);

        var result = await _purchaseService.SaveAsync(purchase);

        if (!result.Success)
            return BadRequest(result.Message);

        var purchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Resource);

        return Ok(purchaseResource);
    }

}