namespace MongoDbBased.API.Data.Interfaces
{
    public interface IChemistryDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CompoundCollection { get; set; }

        public string ChemicalElementCollection { get; set; }
    }
}
