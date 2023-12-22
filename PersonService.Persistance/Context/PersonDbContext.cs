using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonService.Domain.Entities;
using PersonService.Persistance.Context.Abstraction;
using PersonService.Persistance.Options;

namespace PersonService.Persistance.Context
{
    public class PersonDbContext : IPersonDbContext
    {
        public PersonDbContext(IOptions<MongoOptions> mongoSettings)
        {
            var settings = mongoSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Persons = database.GetCollection<Person>(settings.CollectionName);
        }

        public IMongoCollection<Person> Persons { get; }
    }
}
