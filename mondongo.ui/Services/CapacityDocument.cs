using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mondongo.ui.Services
{
    public class CapacityDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double TS { get; set; }
        public int Capacity { get; set; }
    }
}