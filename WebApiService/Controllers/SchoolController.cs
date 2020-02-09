using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiContracts.DTO;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        protected readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        // GET: api/School
        [HttpGet]
        public List<SchoolDto> Get()
        {
            IList<SchoolDto> schoolDtos = _schoolService.GetAll();
            return schoolDtos.ToList();
        }

        [HttpGet("{regionname}")]
        public List<SchoolDto> GetByRegionName(string regionname)
        {
            List<SchoolDto> schoolDtos = _schoolService.GetAll(regionname).ToList();
            if (schoolDtos != null)
                return schoolDtos;
            else
                return null;
        }
        [HttpGet("get/{schoolname}")]
        public async Task<SchoolDto> Get(string schoolname)
        {
            SchoolDto schoolDtos = await _schoolService.Get(schoolname);
            if (schoolDtos != null)
                return schoolDtos;
            else
                return null;
        }

        // POST api/school
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] SchoolDto school)
        {
            if (school != null)
            {
                SchoolDto school1 = new SchoolDto();
                school1 = school;
                SchoolDto schoolDto = await _schoolService.Create(school1);
                if (schoolDto != null)
                    return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Task<SchoolDto> schoolDto = _schoolService.Get(id);
            if (schoolDto != null)
            {
                bool isDeleted = await _schoolService.Delete(id);
                if (isDeleted)
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}