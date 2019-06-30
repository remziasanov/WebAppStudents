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
    public class GroupController : ControllerBase
    {
        protected readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        // GET: Group
        [HttpGet]
        public List<GroupDto> Get()
        {
            IList<GroupDto> groupDtos = _groupService.GetAll();
            return groupDtos.ToList();
        }

        [HttpGet("{departmentName}")]
        public List<GroupDto> GetByDepartmentName(string departmentName)
        {
            List<GroupDto> groupDtos = _groupService.GetAll(departmentName).ToList();
            if (groupDtos != null)
                return groupDtos;
            else
                return null;
        }

        //[HttpGet("{departmentId}")]
        //public List<GroupDto> GetByRegionName(int departmentId)
        //{
        //    List<GroupDto> groupDtos = _groupService.GetAll(departmentId).ToList();
        //    if (groupDtos != null)
        //        return groupDtos;
        //    else
        //        return null;
        //}

       
        // POST: api/Group
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Group/5
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
