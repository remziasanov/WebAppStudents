using AppServices.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
   public  interface ICityLocalService : IBaseService<LocalCityDto, int>
    {
        IList<LocalCityDto> GetAll(int RegionId);
        IList<LocalCityDto> GetAll(string regionname);
    }
}
