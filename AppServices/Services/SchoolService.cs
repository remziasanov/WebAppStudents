using AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Services
{
    class SchoolService : ISchoolService
    {
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

        public IList<SchoolDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SchoolDto> Update(SchoolDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
