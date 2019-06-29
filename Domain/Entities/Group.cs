using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Group : EntityBase<int>
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        /// <summary>
        /// Отделение
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
