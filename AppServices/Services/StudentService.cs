using AppServices.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;
using AutoMapper;
using System.Reflection;
using System.Linq.Expressions;

namespace AppServices.Services
{
    public class StudentService : IStudentService
    {
        const string regionName = "region";
        const string localCityName = "localcity";
        const string schoolName = "school";
        const string departmentName = "department";
        const string groupName = "group";
        const string documentName = "maindocument";
        const string teacherName = "teacher";

        protected readonly IStudentRepository _studentRepository;
        protected readonly IGroupRepository _groupRepository;
        protected readonly ICityLocalRepository _cityLocalRepository;
        protected readonly IDepartmentRepository _departmentRepository;
        protected readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IGroupRepository groupRepository, ICityLocalRepository cityLocalRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;
            _cityLocalRepository = cityLocalRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<StudentDto> Create(StudentDto entity)
        {
            Student result = null;
            try
            {
                result = _mapper.Map<Student>(entity);
            }
            catch(Exception ex)
            {
                string mess = ex.Message.ToString();
                throw new Exception();
            }
            Student std = await _studentRepository.Create(result);
            if(std != null)
                return entity;
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            Student std = await _studentRepository.Get(id);
            if (std != null) {
                await _studentRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<StudentDto> Get(int id)
        {
            Student student = await _studentRepository.Get(id);
            StudentDto studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }

        public IList<StudentDto> GetAll()
        {
            try
            {
                IList<Student> students = _studentRepository.GetAll().ToList();
                IList<StudentDto> studentsDto = _mapper.Map<IList<StudentDto>>(students);
                return studentsDto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<StudentDto> Update(StudentDto entity)
        {
            var result = _mapper.Map<Student>(entity);
            await _studentRepository.Update(result);
            return entity;
        }

        public IList<StudentDto>GetStudentsFilter(string property, string value)
        {
            Student student = new Student();

            GetProperties(student, property, value, out Expression<Func<Student, bool>> predicate);
            if (predicate != null)
            {
                IList<Student> students = _studentRepository.GetAllWhere(predicate).ToList();
                IList<StudentDto> studentsDto = _mapper.Map<IList<StudentDto>>(students);
                return studentsDto;
            }
            return null;
        }

        private void GetProperties(Student student, string property, string value, out Expression<Func<Student, bool>> expression)
        {
            expression = null;
            switch (property.ToLower())
            {
                case regionName:
                    expression = x =>
                    x.LocalCity.RegionId
                    .ToString().ToLower() == value.ToLower();
                    break;
                case localCityName:
                    expression = x =>
                    x.LocalCity.CityName
                    .ToString().ToLower() == value.ToLower();
                    break;
                case schoolName:
                    expression = x =>
                    x.School.Title
                    .ToString().ToLower() == value.ToLower();
                    break;
                case departmentName:
                    var result = _departmentRepository.GetAllWhere(t => t.Title == value).Single().Id; 
                    expression = x =>
                    x.Group1.DepartmentId == result || x.Group2.DepartmentId == result || x.Group3.DepartmentId == result;
                    break;
                case groupName:
                    expression = x =>
                    x.Group1.Title
                    .ToString().ToLower() == value.ToLower() ||
                    x.Group2.Title
                    .ToString().ToLower() == value.ToLower() ||
                    x.Group3.Title
                    .ToString().ToLower() == value.ToLower();
                    break;
                case documentName:
                    expression = x =>
                    x.MainDocument.Number.ToString().ToLower() == value.ToLower();
                    break;
                case teacherName:
                    expression = x =>
                    x.Group1.Teacher.ToString().ToLower() == value.ToLower() ||
                    x.Group2.Teacher.ToString().ToLower() == value.ToLower() ||
                    x.Group3.Teacher.ToString().ToLower() == value.ToLower();
                    break;
            default:
                    foreach (PropertyInfo propertyInfo in student.GetType().GetProperties())
                    {
                        if (propertyInfo.Name.ToLower() == property.ToLower())
                        {
                            expression = x => propertyInfo.GetValue(x).ToString().ToLower() == value.ToLower();
                            break;
                        }
                        else
                        {
                            expression = null;
                        }
                    }
                break;
            }
        }
    }
}