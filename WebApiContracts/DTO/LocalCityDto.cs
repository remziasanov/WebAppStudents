using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    public class LocalCityDto : EntityDto<int>
    {
        public string CityName { get; set; }
        public int RegionId { get; set; }
        public RegionDto Region { get; set; }
    }
}
