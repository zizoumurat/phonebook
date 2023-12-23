namespace ReportsService.Api.Configurations.Abstraction;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
