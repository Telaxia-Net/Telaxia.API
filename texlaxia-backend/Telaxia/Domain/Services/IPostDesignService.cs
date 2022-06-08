using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IPostDesignService
{
    Task<IEnumerable<PostDesignResponse>> ListAsync();
    Task<PostDesignResponse> SaveAsync(PostDesign postDesign);
    Task<PostDesignResponse> UpdateAsync(int id, PostDesign postDesign);
    Task<PostDesignResponse> DeleteAsync(int id);
}