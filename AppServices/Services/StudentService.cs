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
        protected readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> Create(StudentDto entity)
        {
            var result = _mapper.Map<Student>(entity);
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
