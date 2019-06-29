using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    public class GroupDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        /// <summary>
        /// Отделение
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
