
using CleanArchitecture.WebApi.Middleware;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

            services.AddOpenApi();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(policy => true);
                });
            });

            services.AddTransient<ExceptionMiddleware>();
        }
    }
}
