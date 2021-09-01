using MongoDB.Driver;
using MongoDbBased.API.Data;
using MongoDbBased.API.Models;
using MongoDbBased.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MongoDbBased.API.Services
{
    public class BenchmarkGenerator: IBenchmarkGenerator
    {
        private IMongoCollection<ChemicalElement> _chemicalElements;

        private IMongoCollection<Compound> _compounds;

        public BenchmarkGenerator(IMongoDatabase database)
        {
            _chemicalElements = database.GetCollection<ChemicalElement>(MongoCollections.CHEMISTRY_ELEMENTS);
            _compounds = database.GetCollection<Compound>(MongoCollections.COMPOUNDS);
        }

        public async Task CreateElementAsync()
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
                    Period = new Random().Next(20),
                    CustomId = Guid.NewGuid()
                });
            }
            Stopwatch time = new Stopwatch();
            time.Start();
            await _chemicalElements.InsertManyAsync(chemix);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task UpdateElementAsync()
        {
            var records =  _chemicalElements.Find(x => true).Limit(1000)
               .Project(x => x.Id).ToEnumerable();
            FilterDefinition<ChemicalElement> filter = Builders<ChemicalElement>.Filter.In("Id", records);
            UpdateDefinition<ChemicalElement> updateDefinition = Builders<ChemicalElement>.Update.Set(x => x.Name, "UpdatedName");
            
            Stopwatch time = new Stopwatch();
            time.Start();
            await _chemicalElements.UpdateManyAsync(filter, updateDefinition );
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task DeleteElementAsync()
        {
            var records = _chemicalElements.Find(x => true).Limit(1000)
               .Project(x => x.Id).ToEnumerable();
            FilterDefinition<ChemicalElement> filter = Builders<ChemicalElement>.Filter.In("Id", records);

            Stopwatch time = new Stopwatch();
            time.Start();
            await _chemicalElements.DeleteManyAsync(filter);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task<IEnumerable<ChemicalElement>> GetAllElementsAsync()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            await _chemicalElements.Find(x => true).Limit(1000).ToListAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
            return await _chemicalElements.Find( x => true).Limit(1).ToListAsync();
        }

        public async Task CreateCompoundAsync()
        {
            var chemix = new List<Compound>();
            var elements = await _chemicalElements.Find(x => true).Limit(3).ToListAsync();
            var elementDetails = new List<ElementDetails>();
            foreach (var element in elements)
            {
                elementDetails.Add(new ElementDetails 
                {
                    AtomicMass = element.AtomicMass,
                    AtomicNumber = element.AtomicNumber,
                    ChemicalSymbol = element.ChemicalSymbol,
                    CustomId = Guid.NewGuid(),
                    Group = element.Group,
                    Name = element.Name,
                    Period = element.Period
                });
            }
            //for (int i = 0; i < 1000; i++)
            //{
            //    chemix.Add(new Compound
            //    {
            //        MolecularFormula = "formula",
            //        Name = "full name",
            //        ChemicalElements = elementDetails,
            //        CompoundCategory = CompoundGroupCategory.Alken,
            //        CustomId = Guid.NewGuid()
            //    });
            //}
            Stopwatch time = new Stopwatch();
            time.Start();
            await _compounds.InsertManyAsync(chemix);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task UpdateCompoundAsync()
        {
            //var records = _compounds.Find(x => true).Limit(1000)
            //   .Project(x => x.Id).ToEnumerable();
            //FilterDefinition<Compound> filter = Builders<Compound>.Filter.In("Id", records);
            //UpdateDefinition<Compound> updateDefinition = Builders<Compound>.Update.Set(x => x.Name, "UpdatedName");

            //Stopwatch time = new Stopwatch();
            //time.Start();
            //await _compounds.UpdateManyAsync(filter, updateDefinition);
            //time.Stop();
            //Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task DeleteCompoundAsync()
        {
            var records = _chemicalElements.Find(x => true).Limit(1000)
               .Project(x => x.Id).ToEnumerable();
            FilterDefinition<Compound> filter = Builders<Compound>.Filter.In("Id", records);

            Stopwatch time = new Stopwatch();
            time.Start();
            await _compounds.DeleteManyAsync(filter);
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
        }

        public async Task<IEnumerable<Compound>> GetAllCompoundsAsync()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            await _compounds.Find(x => true).Limit(1000).ToListAsync();
            time.Stop();
            Debug.WriteLine("ms : " + time.ElapsedMilliseconds);
            return await _compounds.Find(x => true).Limit(1).ToListAsync();
        }
    }
}
