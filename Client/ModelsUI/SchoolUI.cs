using Client.ModelsUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    class SchoolUI : EntityBaseUI<int>
    {
        public string Title { get; set; }
        public virtual LocalCityUI City { get; set; }
    }
}
