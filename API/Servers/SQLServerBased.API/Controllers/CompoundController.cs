using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using SQLServerBased.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Controllers
{
    [Route("api/{categoryId}/compounds")]
    [ApiController]
    public class CompoundController : ControllerBase
    {
        private readonly IBenchmarkGenerator _benchmarkGenerator;

        public CompoundController(
            IBenchmarkGenerator benchmarkGenerator)
        {
            _benchmarkGenerator = benchmarkGenerator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompoundDto>> GetCompounds(int categoryId)
        {
            var compouds = _benchmarkGenerator.GetAllCompunds(categoryId, trackchanges: false);
            return Ok(compouds);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CompoundDto>> GetCompounds(int categoryId, int id)
        {
            var compouds = _benchmarkGenerator.GetCompund(categoryId, id, trackchanges: false);
            return Ok(compouds);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChemicalElement()
        {
            await _benchmarkGenerator.CreateCompundAsync();
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
