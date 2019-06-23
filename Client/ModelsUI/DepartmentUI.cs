using Client.ModelsUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    public class DepartmentUI : EntityBaseUI<int>
    {
        public string Title { get; set; }
        public List<GroupUI> Groups { get; set; }
    }
}
