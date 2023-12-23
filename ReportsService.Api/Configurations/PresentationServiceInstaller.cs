using ReportsService.Api.Configurations.Abstraction;

namespace ReportsService.Api.Configurations;

public class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {

        services.AddCors(options => options.AddDefaultPolicy(options =>
        {
            options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(options => true);
        }));

        services.AddControllers()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
