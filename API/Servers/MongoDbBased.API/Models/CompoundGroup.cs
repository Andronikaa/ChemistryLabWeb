using System;
using System.Collections.Generic;

namespace MongoDbBased.API.Models
{
    public class CompoundGroup
    {
        public Guid CustomId { get; set; }

        public string CompoundGroupCategory { get; set; }

        public List<Structure> Structures{ get; set; }

    }
}
