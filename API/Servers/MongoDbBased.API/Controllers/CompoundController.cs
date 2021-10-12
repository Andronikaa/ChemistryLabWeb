using Microsoft.AspNetCore.Mvc;
using MongoDbBased.API.Models;
using MongoDbBased.API.Models.Dto;
using MongoDbBased.API.Requests;
using MongoDbBased.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MongoDbBased.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompoundController : ControllerBase
    {
        private readonly IMongoCompoundRepository _compoundRepository;

        public CompoundController(
            IMongoCompoundRepository compoundRepository)
        {
            _compoundRepository = compoundRepository;
        }

        [HttpGet]
        [Route("structures")]
        public  ActionResult<IEnumerable<Compound>> GetCompounds([FromQuery] GetCompoundRequest getCompoundRequest)
        {
            //TODO: null handler needed!
            var structures = _compoundRepository.GetAllStructures(getCompoundRequest);
            var paged = new PagedStructuresDto
            {
                Pages = structures.Count(),
                Structures = structures.Skip((getCompoundRequest.PageNumber - 1) * getCompoundRequest.PageSize)
                   .Take(getCompoundRequest.PageSize)
            };
            return Ok(paged);
        }

        [HttpGet]
        [Route("compounds-names")]
        public async Task<ActionResult<IEnumerable<string>>> GetCompoundsNames()
        {
            return Ok(await _compoundRepository.GetAllCompoundNamesAsync());
        }

        [HttpGet]
        [Route("compounds-groups")]
        public ActionResult<IEnumerable<string>> GetCompoundGroups(string groupName)
        {
            return Ok(_compoundRepository.GetCompoundGroups(groupName));
        }

        [HttpGet]
        [Route("compounds-count")]
        public ActionResult<IEnumerable<string>> GetCompoundCount()
        {
            return Ok(_compoundRepository.GetCompoundCount());
        }
    }
}
