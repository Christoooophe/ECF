using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECF.Models
{
    public class Statistiques
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string StatistiqueName { get; set; } = null!;

        public decimal Data { get; set; }
    }
}
