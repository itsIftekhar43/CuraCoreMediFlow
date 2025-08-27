using CuraCoreMediFlow.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuraCoreMediFlow.Domain.Interfaces
{
    public interface IHospitalRepository
    {
        Task<HospitalAccount?> GetByIdAsync(Guid id);
        Task<HospitalAccount?> GetByIdentifierAsync(string identifier);
        Task AddAsync(HospitalAccount hospital);
        Task<IEnumerable<HospitalAccount>> GetAllAsync();
    }
}
