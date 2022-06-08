using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Domain.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> ListAsync();
    Task<PostResponse> SaveAsync(Post postDesign);
    Task<PostResponse> UpdateAsync(int id, Post postDesign);
    Task<PostResponse> UpdateAsyncLikes(int id, Post postDesign);
    Task<PostResponse> DeleteAsync(int id);
}