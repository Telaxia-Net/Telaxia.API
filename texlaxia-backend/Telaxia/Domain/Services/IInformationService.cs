using System.Collections.Generic;
using System.Threading.Tasks;
using Telaxia_Backend.Telaxia.Domain.Models;
using Telaxia_Backend.Telaxia.Domain.Services.Communication;

namespace Telaxia_Backend.Telaxia.Domain.Services
{
    public interface IInformationService
    {
        Task<IEnumerable<Information>> ListAsync();
        Task<InformationResponse> SaveAsync(Information information);
        Task<InformationResponse> UpdateAsync(int id, Information information);
        Task<InformationResponse> DeleteAsync(int id);
    }
}