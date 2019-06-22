using AppServices.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
    public interface IRegionService : IBaseService<RegionDto, int>
    {
        Task<RegionDto> Get(string title);
    }
}
