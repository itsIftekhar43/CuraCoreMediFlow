using CuraCoreMediFlow.CDB.Infrastructure.Persistence;
using CuraCoreMediFlow.CDB.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CuraCoreMediFlow.Domain.Interfaces;

namespace CuraCoreMediFlow.CDB.Infrastructure
{
    public static class CentralDbDependencyInjection
    {
        public static IServiceCollection AddCentralDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CentralDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("CentralConnection")));

            // Register CentralDB repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IUserRoleHospitalRepository, UserRoleHospitalRepository>();

            return services;
        }
    }
}
