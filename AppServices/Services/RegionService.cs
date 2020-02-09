using AppServices.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Services
{
    public class RegionService : IRegionService
    {
        protected readonly IRegionRepository _regionRepository;
        protected readonly IMapper _mapper;

        public RegionService(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<RegionDto> Create(RegionDto entity)
        {
            Region result = null;
            try
            {
                result = _mapper.Map<Region>(entity);
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
                throw new Exception();
            }
            Region std = await _regionRepository.Create(result);
            if (std != null)
                return entity;
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            Region std = await _regionRepository.Get(id);
            if (std != null)
            {
                await _regionRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<RegionDto> Get(int id)
        {
            Region region = await _regionRepository.Get(id);
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return regionDto;
        }

        public async Task<RegionDto> Get(string title)
        {
            IQueryable<Region> region = _regionRepository.GetAll().Where(x => x.NameRegion == title);
            if(region != null)
            {
                RegionDto regionDto = _mapper.Map<RegionDto>(region.SingleAsync());
                return regionDto;
            }
            return null;

        }

        public IList<RegionDto> GetAll()
        {
            IList<Region> regions = _regionRepository.GetAll().ToList();
            IList<RegionDto> regionsDto = _mapper.Map<IList<RegionDto>>(regions);
            return regionsDto;
        }

        public async Task<RegionDto> Update(RegionDto entity)
        {
            var result = _mapper.Map<Region>(entity);
            await _regionRepository.Update(result);
            return entity;
        }
    }
}
