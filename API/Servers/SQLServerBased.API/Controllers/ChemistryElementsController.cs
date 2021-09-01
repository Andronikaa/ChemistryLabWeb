using Microsoft.AspNetCore.Mvc;
using SQLServerBased.API.Data.Repositories.Interfaces;
using SQLServerBased.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Controllers
{
    [Route("api/chemistry-elements")]
    [ApiController]
    public class ChemistryElementsController : ControllerBase
    {
        private readonly IBenchmarkGenerator _chemicalElementsRepository;

        public ChemistryElementsController(IBenchmarkGenerator chemicalElementsRepository)
        {
            _chemicalElementsRepository = chemicalElementsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChemicalElement()
        {
            await _chemicalElementsRepository.CreateAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChemicalElement>>> GetChemicalElements()
        {
            return Ok(await _chemicalElementsRepository.GetAllAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChemicalElement()
        {
            await _chemicalElementsRepository.UpdateAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChemicalElement()
        {
            await _chemicalElementsRepository.DeleteAsync();
            return Ok();
        }
    }
}
