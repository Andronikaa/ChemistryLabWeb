using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbBased.API.Data.Interfaces;
using MongoDbBased.API.Extensions;
using MongoDbBased.API.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MongoDbBased.API.Services
{
    public static class DataInjector
    {
        public static void SeedDatabase(IChemistryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            if (!CollectionExists(database, settings.ChemicalElementCollection))
                SeedChemicalElementCollection(database, settings.ChemicalElementCollection);

            if (!CollectionExists(database, settings.CompoundCollection))
                SeedCompoundCollection(database, settings.CompoundCollection);
        }

        private static void SeedChemicalElementCollection(IMongoDatabase database, string collectionName)
        {
            var _chemicalElement = database.GetCollection<ChemicalElement>(collectionName);
            var chemicalElements = new List<ChemicalElement>
            {
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Wodór", ChemicalSymbol = "H", Group = 1, Period = 1, AtomicMass = 1.01, AtomicNumber = 1 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Lit", ChemicalSymbol = "Li", Group = 1, Period = 2, AtomicMass = 6.94, AtomicNumber = 3 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Sód", ChemicalSymbol = "Na", Group = 1, Period = 3, AtomicMass = 23, AtomicNumber = 11 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Potas", ChemicalSymbol = "K", Group = 1, Period = 4, AtomicMass = 39.19, AtomicNumber = 19 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Rabid", ChemicalSymbol = "Rb", Group = 1, Period = 5, AtomicMass = 85.47, AtomicNumber = 37 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Cez", ChemicalSymbol = "Cs", Group = 1, Period = 6, AtomicMass = 132.91, AtomicNumber = 55 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Frans", ChemicalSymbol = "Fr", Group = 1, Period = 7, AtomicMass = 223.02, AtomicNumber = 87 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Beryl", ChemicalSymbol = "Be", Group = 2, Period = 2, AtomicMass = 9.01, AtomicNumber = 4 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Magnez", ChemicalSymbol = "Mg", Group = 2, Period = 3, AtomicMass = 24.31, AtomicNumber = 12 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Wapń", ChemicalSymbol = "Ca", Group = 2, Period = 4, AtomicMass = 40.08, AtomicNumber = 20 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Stront", ChemicalSymbol = "Sr", Group = 2, Period = 5, AtomicMass = 87.62, AtomicNumber = 38 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Bar", ChemicalSymbol = "Ba", Group = 2, Period = 6, AtomicMass = 137.33, AtomicNumber = 56 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Rad", ChemicalSymbol = "Ra", Group = 2, Period = 7, AtomicMass = 226.03, AtomicNumber = 85 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Skand", ChemicalSymbol = "Sc", Group = 3, Period = 4, AtomicMass = 44.96, AtomicNumber = 21 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Itr", ChemicalSymbol = "Y", Group = 3, Period = 5, AtomicMass = 88.91, AtomicNumber = 39 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Lantan", ChemicalSymbol = "La", Group = 3, Period = 6, AtomicMass = 138.91, AtomicNumber = 57 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Aktyn", ChemicalSymbol = "Ac", Group = 3, Period = 7, AtomicMass = 227.03, AtomicNumber = 89 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Tytan", ChemicalSymbol = "Ti", Group = 4, Period = 4, AtomicMass = 47.88, AtomicNumber = 22 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Cyrkon", ChemicalSymbol = "Zr", Group = 4, Period = 5, AtomicMass = 91.22, AtomicNumber = 40 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Hafn", ChemicalSymbol = "Hf", Group = 4, Period = 6, AtomicMass = 178.49, AtomicNumber = 72 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Ruterford", ChemicalSymbol = "Rf", Group = 4, Period = 7, AtomicMass = 261.11, AtomicNumber = 104 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Wanad", ChemicalSymbol = "V", Group = 5, Period = 4, AtomicMass = 50.94, AtomicNumber = 23 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Niob", ChemicalSymbol = "Nb", Group = 5, Period = 5, AtomicMass = 92.91, AtomicNumber = 41 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Tantal", ChemicalSymbol = "Ta", Group = 5, Period = 6, AtomicMass = 180.95, AtomicNumber = 73 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Dubm", ChemicalSymbol = "Db", Group = 5, Period = 7, AtomicMass = 263.11, AtomicNumber = 105 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Chrom", ChemicalSymbol = "Cr", Group = 6, Period = 4, AtomicMass = 52, AtomicNumber = 24 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Molibden", ChemicalSymbol = "Mo", Group = 6, Period = 5, AtomicMass = 95.94, AtomicNumber = 42 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Wolfram", ChemicalSymbol = "W", Group = 6, Period = 6, AtomicMass = 183.21, AtomicNumber = 74 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Seaborg", ChemicalSymbol = "Sg", Group = 6, Period = 7, AtomicMass = 265.12, AtomicNumber = 106 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Mangan", ChemicalSymbol = "Mn", Group = 7, Period = 4, AtomicMass = 54.94, AtomicNumber = 25 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Technet", ChemicalSymbol = "Te", Group = 7, Period = 5, AtomicMass = 97.91, AtomicNumber = 43 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Rem", ChemicalSymbol = "Re", Group = 7, Period = 6, AtomicMass = 186.21, AtomicNumber = 75 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Bohr", ChemicalSymbol = "Bh", Group = 7, Period = 7, AtomicMass = 264.10, AtomicNumber = 107 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Żelazo", ChemicalSymbol = "Fe", Group = 8, Period = 4, AtomicMass = 55.85, AtomicNumber = 26 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Ruten", ChemicalSymbol = "Ru", Group = 8, Period = 5, AtomicMass = 101.07, AtomicNumber = 44 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Osm", ChemicalSymbol = "Os", Group = 8, Period = 6, AtomicMass = 190.23, AtomicNumber = 76 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Has", ChemicalSymbol = "Hs", Group = 8, Period = 7, AtomicMass = 269.10, AtomicNumber = 108 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Kobalt", ChemicalSymbol = "Co", Group = 9, Period = 4, AtomicMass = 58.93, AtomicNumber = 27 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Rod", ChemicalSymbol = "Rh", Group = 9, Period = 5, AtomicMass = 102.91, AtomicNumber = 45 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Iryd", ChemicalSymbol = "Ir", Group = 9, Period = 6, AtomicMass = 192.22, AtomicNumber = 77 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Meitner", ChemicalSymbol = "Mt", Group = 9, Period = 7, AtomicMass = 268.10, AtomicNumber = 109 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Nikiel", ChemicalSymbol = "Ni", Group = 10, Period = 4, AtomicMass = 58.69, AtomicNumber = 28 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Pallad", ChemicalSymbol = "Pd", Group = 10, Period = 5, AtomicMass = 106.42, AtomicNumber = 46 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Platyna", ChemicalSymbol = "Pt", Group = 10, Period = 6, AtomicMass = 195.97, AtomicNumber = 78 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Darmsztad", ChemicalSymbol = "Ds", Group = 10, Period = 7, AtomicMass = 281.10, AtomicNumber = 110 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Miedź", ChemicalSymbol = "Cu", Group = 11, Period = 4, AtomicMass = 63.546, AtomicNumber = 29 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Srebro", ChemicalSymbol = "Ag", Group = 11, Period = 5, AtomicMass = 107.868, AtomicNumber = 47 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Złoto", ChemicalSymbol = "Au", Group = 11, Period = 6, AtomicMass = 196.967, AtomicNumber = 79 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Roentgen", ChemicalSymbol = "Rg", Group = 11, Period = 7, AtomicMass = 280, AtomicNumber = 111 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Cynk", ChemicalSymbol = "Zn", Group = 12, Period = 4, AtomicMass = 65.38, AtomicNumber = 30 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Kadm", ChemicalSymbol = "Cd", Group = 12, Period = 5, AtomicMass = 112.411, AtomicNumber = 48 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Rtęć", ChemicalSymbol = "Hg", Group = 12, Period = 6, AtomicMass = 200.59, AtomicNumber = 80 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Kopernik", ChemicalSymbol = "Cn", Group = 12, Period = 7, AtomicMass = 285, AtomicNumber = 112 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Bor", ChemicalSymbol = "B", Group = 13, Period = 2, AtomicMass = 10.811, AtomicNumber = 5 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Glin", ChemicalSymbol = "Al", Group = 13, Period = 3, AtomicMass = 26.982, AtomicNumber = 13 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Gal", ChemicalSymbol = "Ga", Group = 13, Period = 4, AtomicMass = 69.723, AtomicNumber = 31 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Ind", ChemicalSymbol = "In", Group = 13, Period = 5, AtomicMass = 114.818, AtomicNumber = 49 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Tal", ChemicalSymbol = "Ta", Group = 13, Period = 6, AtomicMass = 204.383, AtomicNumber = 81 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Nihonium", ChemicalSymbol = "Nh", Group = 13, Period = 7, AtomicMass = 284, AtomicNumber = 113 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Węgiel", ChemicalSymbol = "C", Group = 14, Period = 2, AtomicMass = 12.011, AtomicNumber = 6 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Krzem", ChemicalSymbol = "Si", Group = 14, Period = 3, AtomicMass = 28.085, AtomicNumber = 14 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "German", ChemicalSymbol = "Ge", Group = 14, Period = 4, AtomicMass = 72.630, AtomicNumber = 32 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Cyna", ChemicalSymbol = "Sn", Group = 14, Period = 5, AtomicMass = 118.710, AtomicNumber = 50 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Ołów", ChemicalSymbol = "Pb", Group = 14, Period = 6, AtomicMass = 207.200, AtomicNumber = 82 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Flerovium", ChemicalSymbol = "Fl", Group = 14, Period = 7, AtomicMass = 289, AtomicNumber = 114 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Azot", ChemicalSymbol = "N", Group = 15, Period = 2, AtomicMass = 14.007, AtomicNumber = 7 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Fosfor", ChemicalSymbol = "P", Group = 15, Period = 3, AtomicMass = 30.974, AtomicNumber = 15 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Arsen", ChemicalSymbol = "As", Group = 15, Period = 4, AtomicMass = 74.922, AtomicNumber = 33 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Antymon", ChemicalSymbol = "Sb", Group = 15, Period = 5, AtomicMass = 121.760, AtomicNumber = 51 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Bizmut", ChemicalSymbol = "Bi", Group = 15, Period = 6, AtomicMass = 208.980, AtomicNumber = 83 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Moscovium", ChemicalSymbol = "Mc", Group = 15, Period = 7, AtomicMass = 288, AtomicNumber = 115 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Tlen", ChemicalSymbol = "O", Group = 16, Period = 2, AtomicMass = 15.999, AtomicNumber = 8 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Siarka", ChemicalSymbol = "S", Group = 16, Period = 3, AtomicMass = 32.065, AtomicNumber = 16 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Selen", ChemicalSymbol = "Se", Group = 16, Period = 4, AtomicMass = 78.960, AtomicNumber = 34 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Tellur", ChemicalSymbol = "Te", Group = 16, Period = 5, AtomicMass = 127.600, AtomicNumber = 52 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Polon", ChemicalSymbol = "Po", Group = 16, Period = 6, AtomicMass = 208.982, AtomicNumber = 84 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Livemorium", ChemicalSymbol = "Lv", Group = 16, Period = 7, AtomicMass = 293, AtomicNumber = 116 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Fluor", ChemicalSymbol = "F", Group = 17, Period = 2, AtomicMass = 18.998, AtomicNumber = 9 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Chlor", ChemicalSymbol = "Cl", Group = 17, Period = 3, AtomicMass = 35.453, AtomicNumber = 17 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Brom", ChemicalSymbol = "Br", Group = 17, Period = 4, AtomicMass = 79.904, AtomicNumber = 35 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Jod", ChemicalSymbol = "I", Group = 17, Period = 5, AtomicMass = 126.904, AtomicNumber = 53 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Astat", ChemicalSymbol = "At", Group = 17, Period = 6, AtomicMass = 209.987, AtomicNumber = 85 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Tennessine", ChemicalSymbol = "Ts", Group = 17, Period = 7, AtomicMass = 294, AtomicNumber = 117 },

                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Hel", ChemicalSymbol = "He", Group = 18, Period = 2, AtomicMass = 4.003, AtomicNumber = 2 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Neon", ChemicalSymbol = "Ne", Group = 18, Period = 3, AtomicMass = 20.180, AtomicNumber = 10 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Argon", ChemicalSymbol = "Ar", Group = 18, Period = 4, AtomicMass = 39.948, AtomicNumber = 18 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Krypton", ChemicalSymbol = "Kr", Group = 18, Period = 5, AtomicMass = 83.798, AtomicNumber = 36 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Ksenon", ChemicalSymbol = "Xe", Group = 18, Period = 6, AtomicMass = 131.293, AtomicNumber = 54 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Radon", ChemicalSymbol = "Rn", Group = 18, Period = 7, AtomicMass = 222.018, AtomicNumber = 86 },
                new ChemicalElement { CustomId = Guid.NewGuid(), Name = "Organesson", ChemicalSymbol = "Og", Group = 18, Period = 7, AtomicMass = 294, AtomicNumber = 118 }

            };
            _chemicalElement.InsertMany(chemicalElements);
        }

        private static void SeedCompoundCollection(IMongoDatabase database, string collectionName)
        {
            var _compoundCollection = database.GetCollection<Compound>(collectionName);
            var compounds = new List<Compound>();


            //HYDROCARBONS
            var hydrocarbons = new Compound
            {
                CustomId = Guid.NewGuid(),
                Name = CompoundName.Węglowodory.GetDisplayName(),
                Description = "Podstawowym składnikiem wszystkich cząsteczek związków organicznych jest szkielet zbudowany" +
                    " z atomów węgla. Atomy węgla są powiązane z atomami wodoru lub grupami zawierającymi atomy innych pierwiastków, " +
                    "np. tlenu, azotu, siarki. Takie grupy noszą nazwę grup funkcyjnych i stanowią zawsze centrum reaktywności cząsteczek " +
                    "i decydują o charakterze związku. W cząsteczkach złożonych wyłącznie z atomów węgla, a także wodoru centra aktywności" +
                    " stanowią podwójne i potrójne wiązania między atomami. Wiązania pojedyncze są zasadniczo niereaktywne. Węglowodorami " +
                    "nazywamy wszystkie związki zbudowane właśnie z węgla i wodoru. Węglowodory dzieli się zwykle na dwie grupy: " +
                    "węglowodory alifatyczne i węglowodory aromatyczne. Wśród węglowodorów alifatycznych rozróżnia się" +
                    " z kolei – w zależności od typu wiązań między atomami węgla węglowodory nasycone (alkany) i nienasycone " +
                    "(alkeny i alkiny). Węglowodory są nierozpuszczalne w wodzie.",
                 Groups = new List<CompoundGroup>()
            };

            var hydrocarbonChemicalElements = new List<ElementDetails>
            {
               new ElementDetails { Name = "Węgiel", ChemicalSymbol = "C", Group = 14, Period = 2, AtomicMass = 12.011, AtomicNumber = 6 },
               new ElementDetails { Name = "Wodór", ChemicalSymbol = "H", Group = 1, Period = 1, AtomicMass = 1.01, AtomicNumber = 1 }
            };

            var alkaneGroup = new CompoundGroup {CustomId = Guid.NewGuid(), CompoundGroupCategory = CompoundGroupCategory.Alkan.ToString(), Structures = new List<Structure>() };

            alkaneGroup.Structures.Add(CreateStructure("Metan", "CH4", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Etan", "C2H6", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Propan", "C3H8", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Butan", "C4H10", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Pentan", "C5H12", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Heksan", "C6H14", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Heptan", "C7H16", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Oktan", "C8H18", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Nonan", "C9H20", hydrocarbonChemicalElements));
            alkaneGroup.Structures.Add(CreateStructure("Dekan", "C10H22", hydrocarbonChemicalElements));

            var alkeneGroup = new CompoundGroup { CustomId = Guid.NewGuid(), CompoundGroupCategory = CompoundGroupCategory.Alken.ToString(), Structures = new List<Structure>() };

            alkeneGroup.Structures.Add(CreateStructure("Eten", "C2H4", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Propen", "C3H6", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Buten", "C4H8", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Penten", "C5H10", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Heksen", "C6H12", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Hepten", "C7H14", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Okten", "C8H16", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Nonen", "C9H18", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Deken", "C10H20", hydrocarbonChemicalElements));
            alkeneGroup.Structures.Add(CreateStructure("Undeken", "C10H22", hydrocarbonChemicalElements));

            var alkylGroup = new CompoundGroup { CustomId = Guid.NewGuid(), CompoundGroupCategory = CompoundGroupCategory.Aren.ToString(), Structures = new List<Structure>() };

            alkylGroup.Structures.Add(CreateStructure("Metylobenzen", null, hydrocarbonChemicalElements, "Toluen", "toluene50px.jpg"));
            alkylGroup.Structures.Add(CreateStructure("1,2-dimetylobenzen", null, hydrocarbonChemicalElements, "Orto-ksylen", "12dimetylobenzen50px.png"));
            alkylGroup.Structures.Add(CreateStructure("1,3-dimetylobenzen", null, hydrocarbonChemicalElements, "Meta-ksylen", "13dimetylobebenzen50px.png"));
            alkylGroup.Structures.Add(CreateStructure("1,4-dimetylobenzen", null, hydrocarbonChemicalElements, "Para-ksylen", "14dimetylobenzen50px.png"));

            hydrocarbons.Groups.Add(alkaneGroup);
            hydrocarbons.Groups.Add(alkeneGroup);
            hydrocarbons.Groups.Add(alkylGroup);

            compounds.Add(hydrocarbons);

            //HYDROCARBON DERIVATIVES
            var hydrocarbonDerivatives = new Compound
            {
                CustomId = Guid.NewGuid(),
                Name = CompoundName.Hydroksylowe_Pochodne_Węglowodorów.GetDisplayName(),
                Description = "Grupą funkcyjną, zarówno alkoholi, jak i fenoli, jest grupa hydroksylowa. Oba związki różnią się jednak tym, że w alkoholach grupa funkcyjna jest przyłączona do tetraedrycznego atomu węgla(o hybrydyzacji sp3) grupy alkilowej. Z kolei w fenolach jest powiązana z atomem węgla pierścieniem aromatycznym o hybrydyzacji sp2.",
                Groups = new List<CompoundGroup>()
            };

            var hydrocarbonDerivativesChemicalElements = new List<ElementDetails>
            {
               new ElementDetails { Name = "Węgiel", ChemicalSymbol = "C", Group = 14, Period = 2, AtomicMass = 12.011, AtomicNumber = 6 },
               new ElementDetails { Name = "Wodór", ChemicalSymbol = "H", Group = 1, Period = 1, AtomicMass = 1.01, AtomicNumber = 1 },
               new ElementDetails { Name = "Tlen", ChemicalSymbol = "O", Group = 16, Period = 2, AtomicMass = 15.999, AtomicNumber = 8 }
            };

            var alcohols = new CompoundGroup { CustomId = Guid.NewGuid(), CompoundGroupCategory = CompoundGroupCategory.Alkohol.ToString(), Structures = new List<Structure>()};

            alcohols.Structures.Add(CreateStructure("Etanol", "CH3CH2OH", hydrocarbonDerivativesChemicalElements, "Alkohol etylowy"));
            alcohols.Structures.Add(CreateStructure("Etano-1,2-diol", null, hydrocarbonDerivativesChemicalElements, "Glikol etylenowy"));
            alcohols.Structures.Add(CreateStructure("Propano-1,2,3-triol", null, hydrocarbonDerivativesChemicalElements, "Gliceryna"));
            alcohols.Structures.Add(CreateStructure("Propan-2-ol", null, hydrocarbonDerivativesChemicalElements, "Izopropanol"));
            alcohols.Structures.Add(CreateStructure("2-metylopropan-2-ol", null, hydrocarbonDerivativesChemicalElements, "Alkohol tert-butylowy"));

            var phenols = new CompoundGroup { CustomId = Guid.NewGuid(), CompoundGroupCategory = CompoundGroupCategory.Fenol.ToString(), Structures = new List<Structure>() };

            phenols.Structures.Add(CreateStructure("Benzenol", null, hydrocarbonDerivativesChemicalElements, "Fenol"));
            phenols.Structures.Add(CreateStructure("Benzeno-1,3-diol", null, hydrocarbonDerivativesChemicalElements, "Rezorcyna"));

            hydrocarbonDerivatives.Groups.Add(alcohols);
            hydrocarbonDerivatives.Groups.Add(phenols);

            compounds.Add(hydrocarbonDerivatives);

            _compoundCollection.InsertMany(compounds);
        }

        private static bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }

        private static Structure CreateStructure(string compoundName, string molecularFormula, List<ElementDetails> chemicalElements, string customName = null, string imageName = null)
        {
            return new Structure
            {
                CustomId = Guid.NewGuid(),
                Name = compoundName,
                CommonName = customName,
                MolecularFormula = molecularFormula,
                ContentImage = imageName == null ? null : File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\Photos\\" + imageName),
                ChemicalElements = chemicalElements
            };
        }
    }
}
