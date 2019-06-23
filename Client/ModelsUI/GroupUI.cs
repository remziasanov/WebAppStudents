using Client.ModelsUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    public class GroupUI : EntityBaseUI<int>
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        /// <summary>
        /// Отделение
        /// </summary>
        public virtual DepartmentUI Department { get; set; }
    }
}
