﻿using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IPurchaseService
{
    Task<IEnumerable<PurchaseResponse>> ListAsync();
    Task<PurchaseResponse> SaveAsync(Purchase purchase);
    Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase);
    Task<PurchaseResponse> DeleteAsync(int id);
}