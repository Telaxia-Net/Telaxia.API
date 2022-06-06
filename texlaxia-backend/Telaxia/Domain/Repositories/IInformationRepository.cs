using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Telaxia_Backend.Telaxia.Domain.Repositories
{
    public interface IInformationRepository
    {
        Task<IEnumerable<Information>> ListAsync();
        Task AddAsync(Information information);
        Task<Information> FindById(int id);
        void Remove(Information information);
        void Update(Information information);
    }
}