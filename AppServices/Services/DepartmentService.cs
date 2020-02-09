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
        public async Task<DepartmentDto> Create(DepartmentDto entity)
        {
            Department result = null;
            try
            {
                result = _mapper.Map<Department>(entity);
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
                throw new Exception();
            }
            Department std = await _departmentRepository.Create(result);
            if (std != null)
                return entity;
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            Department std = await _departmentRepository.Get(id);
            if (std != null)
            {
                await _departmentRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<DepartmentDto> Get(int id)
        {
            Department department = await _departmentRepository.Get(id);
            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }

        public IList<DepartmentDto> GetAll()
        {
            IList<Department> departments = _departmentRepository.GetAll().ToList();
            IList<DepartmentDto> departmentsDto = _mapper.Map<IList<DepartmentDto>>(departments);
            return departmentsDto;
        }

        public async Task<DepartmentDto> Update(DepartmentDto entity)
        {
            var result = _mapper.Map<Department>(entity);
            await _departmentRepository.Update(result);
            return entity;
        }
    }
}