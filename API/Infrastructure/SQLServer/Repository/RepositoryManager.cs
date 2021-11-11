using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private LaboratoryDbContext _laboratoryDbContext;
        private ICompoundRepository _compoundRepository;
        private IChemicalElementRepository _chemicalElementRepository;

        public RepositoryManager(LaboratoryDbContext laboratoryDbContext)
        {
            _laboratoryDbContext = laboratoryDbContext;
        }
        public IChemicalElementRepository ChemicalElement
        {
            get 
            {
                if (_chemicalElementRepository == null)
                    _chemicalElementRepository = new ChemicalElementRepository(_laboratoryDbContext);

                return _chemicalElementRepository;
            }
        }

        public ICompoundRepository Compound
        {
            get
            {
                if (_compoundRepository == null)
                    _compoundRepository = new CompoundRepository(_laboratoryDbContext);

                return _compoundRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _laboratoryDbContext.SaveChangesAsync();
        }
    }
}
