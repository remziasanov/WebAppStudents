using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Регион или район Крыма
    /// </summary>
    public class Region : EntityBase<int>
    {
        public string NameRegion { get; set; }
        public List<LocalCity> Cities { get; set; }
    }
}
