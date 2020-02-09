using AppServices.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Interfaces
{
    public interface IGroupService : IBaseService<GroupDto, int>
    {
        IList<GroupDto> GetAll(int departmentId);
        IList<GroupDto> GetAll(string departmentName);
        GroupDto Get(string groupName);
    }
}