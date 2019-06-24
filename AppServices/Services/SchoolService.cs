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


        public Task<SchoolDto> Create(SchoolDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolDto> Get(int id)
        {
            throw new NotImplementedException();
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

        public Task<SchoolDto> Update(SchoolDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
