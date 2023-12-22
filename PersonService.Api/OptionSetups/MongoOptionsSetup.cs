using Microsoft.Extensions.Options;
using PersonService.Persistance.Options;

namespace PersonService.Api.OptionSetups;

public sealed class MongoOptionsSetup : IConfigureOptions<MongoOptions>
{
    private readonly IConfiguration _configuration;

    private const string MongoDbSettings = nameof(MongoDbSettings);

    public MongoOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(MongoOptions options)
    {
        _configuration.GetSection(MongoDbSettings).Bind(options);
    }
}