using CuraCoreMediFlow.CDB.Infrastructure.Persistence;
using CuraCoreMediFlow.Domain.Entities;
using CuraCoreMediFlow.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CuraCoreMediFlow.CDB.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CentralDbContext _db;
        public UserRepository(CentralDbContext db) => _db = db;

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id) => await _db.Users.FindAsync(id);

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}
