using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services;

    public interface IPostService
    {
        Task<IEnumerable<Post>> ListAsync();
        Task<PostResponse> SaveAsync(Post post);
        Task<PostResponse> UpdateAsync(int id, Post post);
        Task<PostResponse> DeleteAsync(int id); 
    }
