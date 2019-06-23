using Client.ModelsUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    /// <summary>
    /// Студент малой академии наук
    /// </summary>
    public class StudentUI : EntityBaseUI<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Grade { get; set; }
        public DocumentUI MainDocument { get; set; }
        public string SNILS { get; set; }
        public string MedPolis { get; set; }
        public LocalCityUI LocalCity { get; set; }
        public string Address { get; set; }
        public ushort ApartmentNumber { get; set; }
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
        public GroupUI Group1 { get; set; }
        public GroupUI Group2 { get; set; }
        public GroupUI Group3 { get; set; }
    }
}
