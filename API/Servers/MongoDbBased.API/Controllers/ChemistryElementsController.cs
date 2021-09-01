using Microsoft.AspNetCore.Mvc;
using MongoDbBased.API.Models;
using MongoDbBased.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbBased.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChemistryElementsController : ControllerBase
    {
        private readonly IChemicalElementsRepository _chemicalElementsRepository;

        public ChemistryElementsController(IChemicalElementsRepository chemicalElementsRepository)
        {
            _chemicalElementsRepository = chemicalElementsRepository;
        }


        [HttpGet]
        [Route("chemistry-elements")]
        public async Task<ActionResult<IEnumerable<ChemicalElement>>> GetChemicalElements()
        {
            return Ok(await _chemicalElementsRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("grouped-chemistry-elements")]
        public ActionResult<IEnumerable<ChemicalElement>> GetGroupedChemicalElements()
        {
            var group = _chemicalElementsRepository.GetAllGroupedAsync();
            return Ok(group);
        }
    }
}
