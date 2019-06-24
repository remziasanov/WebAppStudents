using AppServices.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
    public interface ISchoolService : IBaseService<SchoolDto, int>
    {
        IList<SchoolDto> GetAll(int CityId);
        IList<SchoolDto> GetAll(string RegionName);
    }
}
