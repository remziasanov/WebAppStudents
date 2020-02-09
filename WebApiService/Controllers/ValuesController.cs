using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApiContracts.DTO;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        protected readonly IStudentService _studentService;
        protected readonly ICityLocalService _cityLocalService;
        protected readonly IDepartmentService _departmentService;
        protected readonly IGroupService _groupService;
        protected readonly ISchoolService _schoolService;
        public ValuesController(IStudentService studentService, ICityLocalService cityLocalService, IDepartmentService departmentService, IGroupService groupService, ISchoolService schoolService)
        {
            _studentService = studentService;
            _cityLocalService = cityLocalService;
            _departmentService = departmentService;
            _groupService = groupService;
            _schoolService = schoolService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> Get()
        {
            IList<StudentDto> studentDtos = _studentService.GetAll();
            if (studentDtos != null)
            {
                return studentDtos.ToList();
            }
            return null;
        }


        // GET api/values
        [HttpGet]
        [Route("start")]
        public ActionResult<string> Start() 
        {
            return "Server started!";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] StudentDto student)
        {
            if (student != null)
            {
                StudentDto student1 = new StudentDto();

                student1 = student;
                student1.LocalCity = await _cityLocalService.Get(student.LocalCity.Id);
                student1.School = await _schoolService.Get(student.School.Id);
                student1.Group1 = await _groupService.Get(student.Group1.Id);
                if(student.Group2 != null)
                {
                    student1.Group2 = await _groupService.Get(student.Group2.Id);
                    if(student.Group3 != null)
                        student1.Group3 = await _groupService.Get(student.Group3.Id);
                }

                StudentDto studentdto = await _studentService.Create(student1);

                if (studentdto != null)
                    return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("filter/{filter}/{value}")]
        public IEnumerable<StudentDto> GetStudentsFilter(string filter, string value)
         {
            if (filter.Length > 0 && value.Length > 0)
                return _studentService.GetStudentsFilter(filter, value);
            return null;
        }

        [HttpGet]
        [Route("test/")]
        public async Task<HttpResponseMessage> TestTestAdd()
        {
            StudentDto student = new StudentDto()
            {
                Name = "Иван",
                Surname = "Петрищев",
                Fathername = "Сергеевич",
                Email = "petrizhshev@mail.ru",
                Phone = "+7(978)-111-11-11",
                LocalCity = _cityLocalService.Get("Симферополь"),
                School = await _schoolService.Get("Гимназия №1"),
                Address = "Симферополь",
                ApartmentNumber = 1,
                Grade = "11А",
                MainDocument = new DocumentDto
                {
                    DocumentType = DocumentType.Passport,
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2023, 7, 19),
                    Number = "12345",
                    Seria = "A1"
                },
                MedPolis = "12345",
                SNILS = "12345",
                Group1 = _groupService.Get("Физика"),
                Group2 = _groupService.Get("Биология"),
                Group3 = _groupService.Get("Введение в ASP.NET"),
                Parent1 = "Родитель 1",
                Parent1Phone = "+7(978)-999-99-99"
            };
            Task<StudentDto> studentdto = _studentService.Create(student);
            if (studentdto != null)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Task<StudentDto> studentdto = _studentService.Get(id);
            if (studentdto != null)
            {
                bool isDeleted = await _studentService.Delete(id);
                if (isDeleted)
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
