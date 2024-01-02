using PersonService.Api.Configurations.Abstraction;
using PersonService.Api.Middleware;

namespace PersonService.Api.Configurations
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ExceptionMiddleware>();

            services.AddCors(options => options.AddDefaultPolicy(options =>
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(options => true);
            }));

            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            // Lsearn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
