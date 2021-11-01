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

        #region chemical elements
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

        #endregion

        #region compounds
        public IEnumerable<CompoundDto> GetAllCompunds(int categoryId, bool trackChanges)
        {
            //TODO validation for categoryId needed here
            Stopwatch time = new Stopwatch();
            time.Start();
            var compounds = _repositoryManager.Compound.GetAllCompounds(categoryId, trackChanges);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);

            var compoundsDto = _mapper.Map<IEnumerable<CompoundDto>>(compounds);
            return compoundsDto;
        }

        public CompoundDto GetCompund(int categoryId, int id, bool trackChanges)
        {
            //TODO validation for categoryId needed here
            Stopwatch time = new Stopwatch();
            time.Start();
            var compounds = _repositoryManager.Compound.GetCompound(categoryId, id, trackChanges);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);

            var compoundsDto = _mapper.Map<CompoundDto>(compounds);
            return compoundsDto;
        }

        public Compound CreateCompund(CompoundForCreationDto compoundDto, int compoundId)
        {
            var compoundEntity = _mapper.Map<Compound>(compoundDto);
            var category = _laboratoryContext.CompoundCategories.FirstOrDefault(c => c.Id == compoundId);
            compoundEntity.CompoundCategory = category;
            Stopwatch time = new Stopwatch();
            time.Start();
            _repositoryManager.Compound.CreateCompound(compoundEntity);
            _repositoryManager.Save();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);


            return compoundEntity;
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
        #endregion 
    }
}
