using PersonService.Api.Configurations.Abstraction;
using PersonService.Api.OptionSetups;
using PersonService.Application.Services;
using PersonService.Persistance;
using PersonService.Persistance.Context;
using PersonService.Persistance.Context.Abstraction;
using PersonService.Persistance.Services.Mongo;

namespace PersonService.Api.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<MongoOptionsSetup>();
            services.AddScoped<IPersonDbContext, PersonDbContext>();
            services.AddScoped<IPersonService, PersonMongoService>();
            services.AddScoped<IContactInformaionService, ContactInformationMongoService>();
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        }
    }
}
