using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    /// <summary>
    /// Студент малой академии наук
    /// </summary>
    public class StudentDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Grade { get; set; }
        public DocumentDto MainDocument { get; set; }
        public string SNILS { get; set; }
        public string MedPolis { get; set; }
        public LocalCityDto LocalCity { get; set; }
        public string Address { get; set; }
        public uint ApartmentNumber { get; set; }
        /// <summary>
        /// ФИО родителя1 
        /// </summary>
        public string Parent1 { get; set; }
        /// <summary>
        /// Номер телефона родителя1
        /// </summary>
        public string Parent1Phone { get; set; }
        /// <summary>
        /// ФИО родителя2 
        /// </summary>
        public string Parent2 { get; set; }
        /// <summary>
        /// Номер телефона родителя2
        /// </summary>
        public string Parent2Phone { get; set; }
        public GroupDto Group1 { get; set; }
        public GroupDto Group2 { get; set; }
        public GroupDto Group3 { get; set; }
    }
}
