
using CleanArchitecture.Domain.Options;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class DomainServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.Configure<SmtpOptions>(configuration.GetSection("Smtp"));
            services.Configure<RegisterEmailOptions>(configuration.GetSection("RegisterEmailOptions"));
            services.Configure<ConfirmationEmailOptions>(configuration.GetSection("ConfirmationEmailOptions"));
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        }
    }
}
