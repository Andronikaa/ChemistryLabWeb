using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoDbBased.API.Models
{
    public class Compound
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public Guid CustomId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CompoundGroup> Groups { get; set; }

    }
}
