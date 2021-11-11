namespace Entities.Dtos
{
    public class ChemicalElementDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ChemicalSymbol { get; set; }

        public int Group { get; set; }

        public int Period { get; set; }

        public int AtomicNumber { get; set; }

        public double AtomicMass { get; set; }
    }
}
