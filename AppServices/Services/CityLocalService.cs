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
    public class CityLocalService : ICityLocalService
    {
        protected readonly ICityLocalRepository _cityLocalRepository;
        protected readonly IMapper _mapper;
        public CityLocalService(ICityLocalRepository cityLocalRepository, IMapper mapper)
        {
            _cityLocalRepository = cityLocalRepository;
            _mapper = mapper;
        }

        public Task<LocalCityDto> Create(LocalCityDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<LocalCityDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LocalCityDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LocalCityDto> GetAll()
        {
            IList<LocalCity> LocalCities = _cityLocalRepository.GetAll().ToList();
            IList<LocalCityDto> LocalCitiesDto = _mapper.Map<IList<LocalCityDto>>(LocalCities);
            return LocalCitiesDto;
        }

        public IList<LocalCityDto> GetAll(int RegionId)
        {
            IList<LocalCity> LocalCities = _cityLocalRepository.GetAll(RegionId).ToList();
            IList<LocalCityDto> LocalCitiesDto = _mapper.Map<IList<LocalCityDto>>(LocalCities);
            return LocalCitiesDto;
        }

        public IList<LocalCityDto> GetAll(string regionname)
        {
            IList<LocalCity> LocalCities = _cityLocalRepository.GetAll(regionname).ToList();
            IList<LocalCityDto> LocalCitiesDto = _mapper.Map<IList<LocalCityDto>>(LocalCities);
            return LocalCitiesDto;
        }

        public Task<LocalCityDto> Update(LocalCityDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
