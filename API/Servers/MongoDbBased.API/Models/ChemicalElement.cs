using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDbBased.API.Models
{
    public class ChemicalElement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public Guid CustomId { get; set; }

        public string Name { get; set; }

        public string ChemicalSymbol { get; set; }

        public int Group { get; set; }

        public int Period { get; set; }

        public int AtomicNumber { get; set; }

        public double AtomicMass { get; set; }
    }
}
