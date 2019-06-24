﻿using System;
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
    public class SchoolController : ControllerBase
    {
        protected readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

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

        // GET: api/School/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/School
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/School/5
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
