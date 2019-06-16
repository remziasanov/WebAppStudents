using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Department : EntityBase<int>
    {
        public string Title { get; set; }
        public List<Group> Groups { get; set; }
    }
}
