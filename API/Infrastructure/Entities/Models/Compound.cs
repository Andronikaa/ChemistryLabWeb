using System.Collections.Generic;

namespace Entities.Models
{
    public class Compound
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MolecularFormula { get; set; }

        public CompoundCategory CompoundCategory { get; set; }

        public ICollection<ChemicalElement> ChemicalElements { get; set; }
    }
}
