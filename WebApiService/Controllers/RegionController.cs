using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiContracts.DTO;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        protected readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        // GET: api/Region
        [HttpGet]
        public List<RegionDto> Get()
        {
            IList<RegionDto> regionDtos = _regionService.GetAll();
            return regionDtos.ToList();
        }

        // GET: api/Region/5
        [HttpGet("{value}", Name = "GetByTitle")]
        public async Task<RegionDto> GetByTitle(string value)
        {
            RegionDto regionDto = await _regionService.Get(value);
            if (regionDto != null)
                return regionDto;
            else
                return null;
        }

        // POST: api/Region
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Region/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
