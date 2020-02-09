using AppServices.Interfaces.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
    public interface IStudentService : IBaseService<StudentDto, int>
    {
        IList<StudentDto> GetStudentsFilter(string property, string value);
    }
}