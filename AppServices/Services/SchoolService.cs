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
    public class SchoolService : ISchoolService
    {
        protected readonly ISchoolRepository _schoolRepository;
        protected readonly IMapper _mapper;
        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<SchoolDto> Create(SchoolDto entity)
        {
            School result = null;
            try
            {
                result = _mapper.Map<School>(entity);
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
                throw new Exception();
            }
            School std = await _schoolRepository.Create(result);
            if (std != null)
                return entity;
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            School std = await _schoolRepository.Get(id);
            if (std != null)
            {
                await _schoolRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<SchoolDto> Get(int id)
        {
            School school = await _schoolRepository.Get(id);
            SchoolDto schoolDto = _mapper.Map<SchoolDto>(school);
            return schoolDto;
        }

        public async Task<SchoolDto> Get(string SchoolName)
        {
            School school = await _schoolRepository.Get(SchoolName);
            SchoolDto SchoolDto = _mapper.Map<SchoolDto>(school);
            return SchoolDto;
        }

        public IList<SchoolDto> GetAll(int CityId)
        {
            IList<School> Schools = _schoolRepository.GetAll(CityId).ToList();
            IList<SchoolDto> SchoolsDto = _mapper.Map<IList<SchoolDto>>(Schools);
            return SchoolsDto;
        }

        public IList<SchoolDto> GetAll(string CityName)
        {
            IList<School> Schools = _schoolRepository.GetAll(CityName).ToList();
            IList<SchoolDto> SchoolsDto = _mapper.Map<IList<SchoolDto>>(Schools);
            return SchoolsDto;
        }

        public IList<SchoolDto> GetAll()
        {
            IList<School> Schools = _schoolRepository.GetAll().ToList();
            IList<SchoolDto> SchoolsDto = _mapper.Map<IList<SchoolDto>>(Schools);
            return SchoolsDto;
        }

        public async Task<SchoolDto> Update(SchoolDto entity)
        {
            var result = _mapper.Map<School>(entity);
            await _schoolRepository.Update(result);
            return entity;
        }
    }
}