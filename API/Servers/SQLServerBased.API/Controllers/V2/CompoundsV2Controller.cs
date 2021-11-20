using AutoMapper;
using Entities.Dtos;
using Entities.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQLServerBased.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/{v:apiversion}/{categoryId}/compounds")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class CompoundsV2Controller : ControllerBase
    {
        private readonly IBenchmarkGenerator _benchmarkGenerator;
        private readonly IMapper _mapper;

        public CompoundsV2Controller(
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
    }
}
