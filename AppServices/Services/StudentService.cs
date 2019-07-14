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
namespace AppServices.Services
{
    public class StudentService : IStudentService
    {
        protected readonly IStudentRepository _studentRepository;
        protected readonly IGroupRepository _groupRepository;
        protected readonly ICityLocalRepository _cityLocalRepository;
        protected readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IGroupRepository groupRepository, ICityLocalRepository cityLocalRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;
            _cityLocalRepository = cityLocalRepository;
        }

        public async Task<StudentDto> Create(StudentDto entity)
        {
            Student result = null;
            result = _mapper.Map<Student>(entity);

            result.Group1 = await _groupRepository.Get(entity.Group1.Id);
            if (entity.Group2 != null)
            {
                result.Group2 = await _groupRepository.Get(entity.Group2.Id);
                if (entity.Group3 != null)
                {
                    result.Group3 = await _groupRepository.Get(entity.Group3.Id);
                }
            }
            result.LocalCity = await _cityLocalRepository.Get(entity.LocalCity.Id);
            Document document = new Document();
            document.Number = entity.MainDocument.Number;
            document.Seria = entity.MainDocument.Seria;
            document.DateOfBirth = entity.MainDocument.DateOfBirth;
            Enum e = entity.MainDocument.Gender;
            document.Gender = (Domain.Entities.Gender)entity.MainDocument.Gender;
            result.MainDocument = document;
            await _studentRepository.Create(result);
            return entity;
        }

        public Task<StudentDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDto> Get(int id)
        {
            Student student = await _studentRepository.Get(id);
            StudentDto studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }

        public IList<StudentDto> GetAll()
        {
            IList<Student> students = _studentRepository.GetAll().ToList();
            IList<StudentDto> studentsDto = _mapper.Map<IList<StudentDto>>(students);
            return studentsDto;
        }

        public async Task<StudentDto> Update(StudentDto entity)
        {
            var result = _mapper.Map<Student>(entity);
            await _studentRepository.Update(result);
            return entity;
        }
    }
}
