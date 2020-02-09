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
    public class GroupController : Controller
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
        [HttpGet]
        [Route("name/{groupName}")]
        public ActionResult<GroupDto> GetGroup(string groupName)
        {
            GroupDto groupDto = _groupService.Get(groupName);
            if (groupDto != null)
                return groupDto;
            else
                return null;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Group/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Group/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Group/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}