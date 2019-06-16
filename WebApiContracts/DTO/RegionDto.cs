using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    /// <summary>
    /// Регион или район 
    /// </summary>
    public class RegionDto : EntityDto<int>
    {
        public string NameRegion { get; set; }
        public List<LocalCityDto> Cities { get; set; }
    }
}
