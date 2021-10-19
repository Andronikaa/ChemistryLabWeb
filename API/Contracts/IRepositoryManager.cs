namespace Contracts
{
    public interface IRepositoryManager
    {
        IChemicalElementRepository ChemicalElement { get; }

        ICompoundRepository Compound { get; }

        void Save();
    }
}
