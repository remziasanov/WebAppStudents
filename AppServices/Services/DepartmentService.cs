using AppServices.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Services
{
    public class DepartmentService : IDepartmentService
    {
        protected readonly IDepartmentRepository _departmentRepository;
        protected readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public Task<DepartmentDto> Create(DepartmentDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DepartmentDto> GetAll()
        {
            IList<Department> departments = _departmentRepository.GetAll().ToList();
            IList<DepartmentDto> departmentsDto = _mapper.Map<IList<DepartmentDto>>(departments);
            return departmentsDto;
        }

        public Task<DepartmentDto> Update(DepartmentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
