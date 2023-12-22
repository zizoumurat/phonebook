using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonService.Domain.Entities
{
    public class ContactInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
