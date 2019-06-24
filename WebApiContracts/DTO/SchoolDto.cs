using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    public class SchoolDto : EntityDto<int>
    {
        public string Title { get; set; }
        public int RegionId { get; set; }
    }
}
