using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using SQLServerBased.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Controllers
{
    [Route("api/compounds")]
    [ApiController]
    public class CompoundController : ControllerBase
    {
        private readonly IBenchmarkGenerator _benchmarkGenerator;

        public CompoundController(IBenchmarkGenerator benchmarkGenerator)
        {
            _benchmarkGenerator = benchmarkGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChemicalElement()
        {
            await _benchmarkGenerator.CreateCompundAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compound>>> GetChemicalElements()
        {
            await _benchmarkGenerator.GetAllCompundsAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChemicalElement()
        {
            await _benchmarkGenerator.UpdateCompoundAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChemicalElement()
        {
            await _benchmarkGenerator.DeleteCompoundAsync();
            return Ok();
        }

    }
}
