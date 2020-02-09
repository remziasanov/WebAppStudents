using AppServices.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
    public interface ISchoolService : IBaseService<SchoolDto, int>
    {
        IList<SchoolDto> GetAll(int CityId);
        IList<SchoolDto> GetAll(string CityName);
        Task<SchoolDto> Get(string SchoolName);
    }
}
