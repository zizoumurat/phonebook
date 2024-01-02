using MongoDB.Bson.Serialization.Attributes;

namespace PersonService.Domain.Dtos
{
    [BsonIgnoreExtraElements]
    public class LocationReportDto
    {
        [BsonElement("Location")]
        public string Location { get; set; }
        public int PhoneNumberCount { get; set; }
        public int PersonCount { get; set; }
    }
}
