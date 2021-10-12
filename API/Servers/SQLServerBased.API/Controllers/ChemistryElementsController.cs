using Microsoft.AspNetCore.Mvc;
using SQLServerBased.API.Data.Repositories.Interfaces;
using SQLServerBased.API.Models;
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

        public ChemistryElementsController(IBenchmarkGenerator benchmarkGenerator)
        {
            _benchmarkGenerator = benchmarkGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChemicalElement()
        {
            await _benchmarkGenerator.CreateAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChemicalElement>>> GetChemicalElements()
        {
            try
            {
                return Ok(await _benchmarkGenerator.GetAllAsync());
            }
            catch (Exception ex)
            {
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
