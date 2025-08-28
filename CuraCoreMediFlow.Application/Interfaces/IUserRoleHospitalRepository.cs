using CuraCoreMediFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuraCoreMediFlow.Domain.Interfaces
{
    public interface IUserRoleHospitalRepository
    {
        Task AddAsync(UserRoleHospitalMap map);
        Task<IEnumerable<UserRoleHospitalMap>> GetByUserIdAsync(int userId);
    }
}
