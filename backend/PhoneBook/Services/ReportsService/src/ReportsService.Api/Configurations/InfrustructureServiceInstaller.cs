using ReportsService.Api.Configurations.Abstraction;

namespace ReportsService.Api.Configurations;

public interface InfrustructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
