using CuraCoreMediFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuraCoreMediFlow.CDB.Infrastructure.Persistence
{
    public class CentralDbContext:DbContext
    {
        public CentralDbContext(DbContextOptions<CentralDbContext> options) : base(options) { }

        public DbSet<HospitalAccount> HospitalAccounts => Set<HospitalAccount>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRoleHospitalMap> UserRoleHospitalMaps => Set<UserRoleHospitalMap>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HospitalAccount>(eb =>
            {
                eb.HasKey(h => h.Id);
                eb.HasIndex(h => h.Identifier).IsUnique();
                eb.Property(h => h.HospitalName).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasKey(u => u.Id);
                eb.HasIndex(u => u.Username).IsUnique();
                eb.HasIndex(u => u.Email).IsUnique();
                eb.Property(u => u.Username).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Role>(eb =>
            {
                eb.HasKey(r => r.Id);
                eb.HasIndex(r => r.Name).IsUnique();
                eb.Property(r => r.Name).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<UserRoleHospitalMap>(eb =>
            {
                eb.HasKey(m => m.Id);
                eb.HasOne(m => m.User).WithMany().HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
                eb.HasOne(m => m.Role).WithMany().HasForeignKey(m => m.RoleId).OnDelete(DeleteBehavior.Cascade);
                eb.HasOne(m => m.HospitalAccount).WithMany().HasForeignKey(m => m.HospitalAccountId).OnDelete(DeleteBehavior.Cascade);
                eb.HasIndex(m => new { m.UserId, m.RoleId, m.HospitalAccountId }).IsUnique();
            });
        }
    }
}
