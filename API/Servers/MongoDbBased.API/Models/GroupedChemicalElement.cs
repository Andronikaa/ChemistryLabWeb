using System.Collections.Generic;

namespace MongoDbBased.API.Models
{
    public class GroupedChemicalElement
    {
        public int Group { get; set; }

        public IEnumerable<ChemicalElement> ChemicalElements { get; set; }
    }
}
