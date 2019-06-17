using AppServices.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
    public interface IDepartmentService : IBaseService<DepartmentDto, int>
    {

    }
}
