using CuraCoreMediFlow.CDB.Infrastructure.Persistence;
using CuraCoreMediFlow.Domain.Entities;
using CuraCoreMediFlow.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CuraCoreMediFlow.CDB.Infrastructure.Repositories
{
    public class UserRoleHospitalRepository : IUserRoleHospitalRepository
    {
        private readonly CentralDbContext _db;
        public UserRoleHospitalRepository(CentralDbContext db) => _db = db;

        public async Task AddAsync(UserRoleHospitalMap map)
        {
            _db.UserRoleHospitalMaps.Add(map);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRoleHospitalMap>> GetByUserIdAsync(int userId) =>
            await _db.UserRoleHospitalMaps.Where(m => m.UserId == userId).AsNoTracking().ToListAsync();
    }
}
