using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TakeAwayNight.Catalog.Entities
{
    public class Features
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeaturesId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
