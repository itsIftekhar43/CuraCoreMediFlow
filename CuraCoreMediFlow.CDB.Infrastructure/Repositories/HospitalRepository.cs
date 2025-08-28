using CuraCoreMediFlow.CDB.Infrastructure.Persistence;
using CuraCoreMediFlow.Domain.Entities;
using CuraCoreMediFlow.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CuraCoreMediFlow.CDB.Infrastructure.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly CentralDbContext _db;
        public HospitalRepository(CentralDbContext db) => _db = db;

        public async Task AddAsync(HospitalAccount hospital)
        {
            _db.HospitalAccounts.Add(hospital);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HospitalAccount>> GetAllAsync() =>
            await _db.HospitalAccounts.AsNoTracking().ToListAsync();

        public async Task<HospitalAccount?> GetByIdAsync(Guid id) =>
            await _db.HospitalAccounts.FindAsync(id);

        public async Task<HospitalAccount?> GetByIdentifierAsync(string identifier) =>
            await _db.HospitalAccounts.FirstOrDefaultAsync(h => h.Identifier == identifier);
    }
}
