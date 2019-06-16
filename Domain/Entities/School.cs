using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class School : EntityBase<int>
    {
        public string Title { get; set; }
        public virtual LocalCity City { get; set; }
    }
}
