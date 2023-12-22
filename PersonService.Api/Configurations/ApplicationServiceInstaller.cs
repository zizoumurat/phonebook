using FluentValidation;
using MediatR;
using PersonService.Api.Configurations.Abstraction;
using PersonService.Application;
using PersonService.Application.Behavior;


namespace PersonService.Api.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AssemblyReference).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));

            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}
