
using CleanArchitecture.Application.Abstraction;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.WebApi.OptionsSetup;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<IMailService, MailService>();

            services.AddScoped<IJwtProvider, JwtProvider>();

            services.ConfigureOptions<JwtBearerOptionsSetup>();
        }
    }
}
