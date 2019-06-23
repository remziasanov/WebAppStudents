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
    public class CityLocalController : ControllerBase
    {
        protected readonly ICityLocalService _cityService;
        public CityLocalController(ICityLocalService cityService)
        {
            _cityService = cityService;
        }



        // GET: api/CityLocal
        [HttpGet]
        public ActionResult<IEnumerable<LocalCityDto>> Get()
        {
            IList<LocalCityDto> citiesDtos = _cityService.GetAll();
            return citiesDtos.ToList();
        }

        
        [HttpGet("{regionname}")]
        public List<LocalCityDto> GetByTitle(string regionname)
        {
            List<LocalCityDto> citiesDtos = _cityService.GetAll(regionname).ToList();

            if (citiesDtos != null)
                return citiesDtos;
            else
                return null;
        }

        //// GET: api/CityLocal/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/CityLocal
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CityLocal/5
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
