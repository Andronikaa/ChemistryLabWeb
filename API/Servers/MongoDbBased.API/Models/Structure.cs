using System;
using System.Collections.Generic;

namespace MongoDbBased.API.Models
{
    public class Structure
    {
        public Guid CustomId { get; set; }

        public string Name { get; set; }

        public string CommonName { get; set; }

        public string MolecularFormula { get; set; }

        public byte[] ContentImage { get; set; }

        public List<ElementDetails> ChemicalElements { get; set; }

    }
}
