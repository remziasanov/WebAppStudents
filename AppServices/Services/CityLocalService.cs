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

        public async Task<LocalCityDto> Create(LocalCityDto entity)
        {
            LocalCity result = null;
            try
            {
                result = _mapper.Map<LocalCity>(entity);
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
                throw new Exception();
            }
            LocalCity std = await _cityLocalRepository.Create(result);
            if (std != null)
                return entity;
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            LocalCity std = await _cityLocalRepository.Get(id);
            if (std != null)
            {
                await _cityLocalRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<LocalCityDto> Get(int id)
        {
            LocalCity localCity = await _cityLocalRepository.Get(id);
            LocalCityDto localCityDto = _mapper.Map<LocalCityDto>(localCity);
            return localCityDto;
        }

        public LocalCityDto Get(string cityname)
        {
            LocalCity localCity = _cityLocalRepository.Get(cityname);
            if(localCity!=null)
            {
                LocalCityDto localCityDto = _mapper.Map<LocalCityDto>(localCity);
                return localCityDto;
            }
            return null;
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

        public async Task<LocalCityDto> Update(LocalCityDto entity)
        {
            var result = _mapper.Map<LocalCity>(entity);
            await _cityLocalRepository.Update(result);
            return entity;
        }
    }
}
