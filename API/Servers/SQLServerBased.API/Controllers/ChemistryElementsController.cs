using Contracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using SQLServerBased.API.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Controllers
{
    [Route("api/chemistry-elements")]
    [ApiController]
    public class ChemistryElementsController : ControllerBase
    {
        private readonly IBenchmarkGenerator _benchmarkGenerator;
        private readonly ILoggerManager _loggerManager;

        public ChemistryElementsController(
            IBenchmarkGenerator benchmarkGenerator,
            ILoggerManager loggerManager)
        {
            _benchmarkGenerator = benchmarkGenerator;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChemicalElementDto>> GetChemicalElements()
        {
            return Ok(_benchmarkGenerator.GetAllChemicalElements());
        }

        [HttpGet("{id}")]
        public ActionResult<ChemicalElementDto> GetChemicalElement(int id)
        {
            var chemicalElement = _benchmarkGenerator.GetChemicalElement(id, trackChanges: false);
            if (chemicalElement == null)
               return NotFound();
            
            return chemicalElement;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChemicalElement()
        {
            await _benchmarkGenerator.CreateAsync();
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChemicalElement>> GetChemicalElements()
        {
            try
            {
                return Ok(_benchmarkGenerator.GetAllChemicalElementsAsync());
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Exception occured in {nameof(GetChemicalElements)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChemicalElement()
        {
            await _benchmarkGenerator.UpdateAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChemicalElement()
        {
            await _benchmarkGenerator.DeleteAsync();
            return Ok();
        }
    }
}
