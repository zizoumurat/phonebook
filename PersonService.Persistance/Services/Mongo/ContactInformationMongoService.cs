using MongoDB.Bson;
using MongoDB.Driver;
using PersonService.Application.Services;
using PersonService.Domain.Dtos;
using PersonService.Domain.Entities;
using PersonService.Persistance.Context.Abstraction;

namespace PersonService.Persistance.Services.Mongo
{
    public class ContactInformationMongoService : IContactInformaionService
    {
        private readonly IPersonDbContext _personDbContext;

        public ContactInformationMongoService(IPersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public async Task Create(string personId, ContactInformation contactInformation)
        {
            contactInformation.Id = ObjectId.GenerateNewId().ToString();
            var filter = Builders<Person>.Filter.Eq(p => p.Id, personId);
            var update = Builders<Person>.Update.Push(p => p.ContactInformation, contactInformation);

            var result = await _personDbContext.Persons.UpdateOneAsync(filter, update);
        }

        public async Task Delete(string personId, string id)
        {
            var filter = Builders<Person>.Filter.Eq(p => p.Id, personId);
            var update = Builders<Person>.Update.PullFilter(p => p.ContactInformation, ci => ci.Id == id);

            var result = await _personDbContext.Persons.UpdateOneAsync(filter, update);
        }

        public async Task<IList<LocationReportDto>> GetReportList()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$unwind", "$ContactInformation"),
                    new BsonDocument("$group",
                        new BsonDocument
                        {
                            { "_id", "$ContactInformation.Location" },
                            { "PhoneNumberCount", new BsonDocument("$sum", 1) },
                            { "PersonCount", new BsonDocument("$sum", 1) }
                        }
                    ),
                    new BsonDocument("$project",
                        new BsonDocument
                        {
                            { "_id", 0 },
                            { "Location", "$_id" },
                            { "PhoneNumberCount", "$PhoneNumberCount" },
                            { "PersonCount", "$PersonCount" }
                        }
                    )
            };

            return await _personDbContext.Persons.Aggregate<LocationReportDto>(pipeline).ToListAsync();
        }
    }
}
