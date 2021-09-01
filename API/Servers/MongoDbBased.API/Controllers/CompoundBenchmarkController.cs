using Microsoft.AspNetCore.Mvc;
using MongoDbBased.API.Models;
using MongoDbBased.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbBased.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundBenchmarkController : ControllerBase
    {
        private readonly IBenchmarkGenerator _benchmarkGenerator;

        public CompoundBenchmarkController(IBenchmarkGenerator benchmarkGenerator)
        {
            _benchmarkGenerator = benchmarkGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompound()
        {
            await _benchmarkGenerator.CreateCompoundAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compound>>> GetCompound()
        {
            return Ok(await _benchmarkGenerator.GetAllCompoundsAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompound()
        {
            await _benchmarkGenerator.UpdateCompoundAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompound()
        {
            await _benchmarkGenerator.DeleteCompoundAsync();
            return Ok();
        }
    }
}
