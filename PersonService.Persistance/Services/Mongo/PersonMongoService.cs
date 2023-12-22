using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PersonService.Application.Services;
using PersonService.Domain.Entities;
using PersonService.Persistance.Context.Abstraction;

namespace PersonService.Persistance.Services.Mongo
{
    public class PersonMongoService : IPersonService
    {
        private readonly IPersonDbContext _personDbContext;

        public PersonMongoService(IPersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public async Task CreatePerson(Person person)
        {
            await _personDbContext.Persons.InsertOneAsync(person);
        }

        public async Task DeletePerson(string Id)
        {
            await _personDbContext.Persons.DeleteOneAsync(x => x.Id == Id);
        }

        public async Task<IList<Person>> GetAll()
        {
            return await _personDbContext.Persons
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<Person> GetWithDetail(string id)
        {
            var filter = Builders<Person>.Filter.Eq(p => p.Id, id);

            return await _personDbContext.Persons.Find(filter).FirstOrDefaultAsync();
        }
    }
}
