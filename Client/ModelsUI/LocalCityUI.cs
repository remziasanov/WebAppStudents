using Client.ModelsUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    public class LocalCityUI : EntityBaseUI<int>
    {
        public string CityName { get; set; }
        public int RegionId { get; set; }
    }
}
