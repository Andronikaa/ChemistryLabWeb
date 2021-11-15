using AutoMapper;
using Entities.Dtos;
using Entities.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQLServerBased.API.ActionFilters;
using SQLServerBased.API.Data.Repositories.Interfaces;
using SQLServerBased.API.ModelBinders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Controllers
{
    [Route("api/{categoryId}/compounds")]
    [ApiController]
    public class CompoundController : ControllerBase
    {
        private readonly IBenchmarkGenerator _benchmarkGenerator;
        private readonly IMapper _mapper;

        public CompoundController(
            IBenchmarkGenerator benchmarkGenerator,
            IMapper mapper)
        {
            _benchmarkGenerator = benchmarkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompoundDto>>> GetCompoundsAsync(int categoryId, [FromQuery] CompoundParams compoundParams)
        {
            var compouds = await _benchmarkGenerator.GetAllCompundsAsync(categoryId, compoundParams, trackchanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(compouds.MetaData));

           var compoundDto = _mapper.Map<IEnumerable<CompoundDto>>(compouds);
            return Ok(compoundDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompoundDto>> GetCompoundByIdAsync(int categoryId, int id)
        {
            var compouds = await _benchmarkGenerator.GetCompundAsync(categoryId, id, trackchanges: false);
            return Ok(compouds);
        }

        [HttpGet("({ids})")]
        public async Task<ActionResult<CompoundDto>> GetCompoundsByIdsAsync(int categoryId, [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var compouds = await _benchmarkGenerator.GetCompundsByIdsAsync(categoryId, ids, trackChanges: false);
            return Ok(compouds);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompound(int categoryId, [FromBody] CompoundForCreationDto compoundDto)
        {
            var compoudEntity =await _benchmarkGenerator.CreateCompundAsync(compoundDto, categoryId);
            //not working
            //return CreatedAtRoute(
            //    nameof(GetCompoundById),
            //    new { categoryId = compoudEntity.CompoundCategory.Id, id = compoudEntity.Id },
            //    compoudEntity);
            return CreatedAtAction(
                nameof(GetCompoundByIdAsync), 
                new { categoryId = compoudEntity.CompoundCategory.Id, id = compoudEntity.Id }, 
                compoudEntity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChemicalElement()
        {
            await _benchmarkGenerator.UpdateCompoundAsync();
            return Ok();
        }

        //TODO add patch later

        [HttpDelete]
        public async Task<IActionResult> DeleteChemicalElement()
        {
            await _benchmarkGenerator.DeleteCompoundAsync();
            return Ok();
        }
    }
}
