using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SQLServerBased.API.Models
{
    public class CompoundCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Compound> Compounds{ get; set; }
    }
}
