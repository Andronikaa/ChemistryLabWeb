using MongoDbBased.API.Data.Interfaces;

namespace MongoDbBased.API.Data
{
    public class ChemistryDatabaseSettings : IChemistryDatabaseSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
        public string CompoundCollection { get ; set ; }
        public string ChemicalElementCollection { get ; set ; }
    }
}
