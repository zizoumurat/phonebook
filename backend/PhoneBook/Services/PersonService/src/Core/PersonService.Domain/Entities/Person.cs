using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonService.Domain.Entities
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInformation> ContactInformation { get; set; } = new();
    }
}
