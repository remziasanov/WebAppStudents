using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    /// <summary>
    /// Регион или район Крыма
    /// </summary>
    public class RegionUI 
    {
        public int Id { get; set; }
        public string NameRegion { get; set; }
        public List<LocalCityUI> Cities { get; set; }
    }
}
