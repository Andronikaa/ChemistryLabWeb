using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IChemicalElementRepository ChemicalElement { get; }

        ICompoundRepository Compound { get; }

        Task SaveAsync();
    }
}
