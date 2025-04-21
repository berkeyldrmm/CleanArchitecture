
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.WebApi.OptionsSetup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class PersistanceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference));

            services.AddDbContext<CleanArchDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("ApplicationDb")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<CleanArchDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureOptions<IdentityOptionsSetup>();
        }
    }
}
