using AutoMapper;
using Contracts;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SQLServerBased.API.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SQLServerBased.API.Data.Repositories
{
    //TODO refactor: extract to seperate service for each responsibility
    //TODO make it generic
    public class BenchamarkGenerator : IBenchmarkGenerator
    {
        private readonly LaboratoryDbContext _laboratoryContext;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;

        public BenchamarkGenerator(
            LaboratoryDbContext context, 
            IRepositoryManager repositoryManager,
            IMapper mapper,
            ILoggerManager loggerManager)
        {
            _laboratoryContext = context;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        public IEnumerable<ChemicalElementDto> GetAllChemicalElements()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            var chemicalElements = _repositoryManager.ChemicalElement.GetAll(trackChanges: false).Take(100);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
            var chemicalElementsDto = _mapper.Map<IEnumerable<ChemicalElementDto>>(chemicalElements);
            return chemicalElementsDto;
        }

        public ChemicalElementDto GetChemicalElement(int id, bool trackChanges)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            var chemicalElement = _repositoryManager.ChemicalElement.Get(id, trackChanges: false);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);

            if (chemicalElement == null)
                _loggerManager.LogInfo($"Chemical element with id : {id} does not exists.");

            var chemicalElementDto = _mapper.Map<ChemicalElementDto>(chemicalElement);
            return chemicalElementDto;
        }

        public async Task CreateAsync()
        {
            var chemix = new List<ChemicalElement>();
            for (int i = 0; i < 1000; i++)
            {
                chemix.Add(new ChemicalElement 
                { 
                    AtomicMass = new Random().Next(100), 
                    AtomicNumber = new Random().Next(100),
                    ChemicalSymbol = "random",
                    Group = new Random().Next(20),
                    Name = "name",
                    Period = new Random().Next(20)
                });
            }
            Stopwatch time = new Stopwatch();
            time.Start();
            _laboratoryContext.ChemicalElements.AddRange(chemix);
            await _laboratoryContext.SaveChangesAsync();
            time.Stop();
            Debug.WriteLine( "ms : " + time.ElapsedMilliseconds);
        }

        public async Task CreateCompundAsync()
        {
            var chemix = new List<Compound>();
            var elements = await _laboratoryContext.ChemicalElements.Take(3).ToListAsync();
            var category = await _laboratoryContext.CompoundCategories.FirstOrDefaultAsync();

            for (int i = 0; i < 1000; i++)
            {
                chemix.Add(new Compound
                {
                    MolecularFormula = "formula",
                    Name = "full name",
                    ChemicalElements = elements,
                    CompoundCategory = category
                });
            }
            Stopwatch time = new Stopwatch();
            time.Start();
            _laboratoryContext.Compounds.AddRange(chemix);
            await _laboratoryContext.SaveChangesAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task DeleteAsync()
        {
            var chemix = _laboratoryContext.ChemicalElements.Take(10);
            Stopwatch time = new Stopwatch();
            time.Start();
            _laboratoryContext.ChemicalElements.RemoveRange(chemix);
            await _laboratoryContext.SaveChangesAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task DeleteCompoundAsync()
        {
            var chemix = _laboratoryContext.Compounds.Take(1000);
            Stopwatch time = new Stopwatch();
            time.Start();
            _laboratoryContext.Compounds.RemoveRange(chemix);
            await _laboratoryContext.SaveChangesAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

       

        public async Task GetAllCompundsAsync()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            var chemix = await _laboratoryContext.Compounds.Include(x => x.CompoundCategory)
                .Include(x => x.ChemicalElements).Take(1000).ToListAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
            //return chemix;
        }

        public async Task UpdateAsync()
        {
            var chemix = _laboratoryContext.ChemicalElements.Take(1000);
            foreach (var chem in chemix)
            {
                chem.Name = "Updated";
            }
            Stopwatch time = new Stopwatch();
            time.Start();
            _laboratoryContext.ChemicalElements.UpdateRange(chemix);
            await _laboratoryContext.SaveChangesAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task UpdateCompoundAsync()
        {
            var chemix = _laboratoryContext.Compounds.Take(1000);
            foreach (var chem in chemix)
            {
                chem.Name = "Updated";
            }
            Stopwatch time = new Stopwatch();
            time.Start();
            _laboratoryContext.Compounds.UpdateRange(chemix);
            await _laboratoryContext.SaveChangesAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }
    }
}
