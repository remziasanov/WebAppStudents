using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    public class DepartmentDto : EntityDto<int>
    {
        public string Title { get; set; }
        public List<GroupDto> Groups { get; set; }
    }
}
