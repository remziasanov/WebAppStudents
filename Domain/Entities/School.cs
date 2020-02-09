using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class School : EntityBase<int>
    {
        public string Title { get; set; }
        public int CityId { get; set; }

        public static implicit operator Task<object>(School v)
        {
            throw new NotImplementedException();
        }
    }
}
