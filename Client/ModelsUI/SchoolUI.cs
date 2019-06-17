using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    class SchoolUI
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual LocalCityUI City { get; set; }
    }
}
