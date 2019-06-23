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

        public Task<RegionDto> Create(RegionDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<RegionDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegionDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RegionDto> Get(string title)
        {
            List<Region> regions = await _regionRepository.GetAll().ToListAsync();
            Region region = regions.SingleOrDefault(x => x.NameRegion == title);
            if (region != null)
            {
                RegionDto regionDto = _mapper.Map<RegionDto>(region);
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

        public Task<RegionDto> Update(RegionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
