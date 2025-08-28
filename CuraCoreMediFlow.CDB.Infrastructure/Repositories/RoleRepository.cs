using CuraCoreMediFlow.CDB.Infrastructure.Persistence;
using CuraCoreMediFlow.Domain.Entities;
using CuraCoreMediFlow.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CuraCoreMediFlow.CDB.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CentralDbContext _db;
        public RoleRepository(CentralDbContext db) => _db = db;

        public async Task AddAsync(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync() => await _db.Roles.AsNoTracking().ToListAsync();

        public async Task<Role?> GetByIdAsync(Guid id) => await _db.Roles.FindAsync(id);

        public async Task<Role?> GetByNameAsync(string name) =>
            await _db.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }
}
