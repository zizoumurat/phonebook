using MongoDB.Driver;
using PersonService.Domain.Entities;

namespace PersonService.Persistance.Context.Abstraction
{
    public interface IPersonDbContext
    {
        IMongoCollection<Person> Persons { get; }
    }
}
