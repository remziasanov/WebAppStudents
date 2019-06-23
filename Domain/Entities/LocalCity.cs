using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Город или населенный пункт
    /// </summary>
    public class LocalCity : EntityBase<int>
    {
        public string CityName { get; set; }
        public int RegionId { get; set; }
    }
}
