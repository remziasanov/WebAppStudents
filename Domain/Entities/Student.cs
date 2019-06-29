﻿using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Студент малой академии наук
    /// </summary>
    public class Student : EntityBase<int>
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Grade { get; set; }
        [Required]
        public Document MainDocument { get; set; }
        public string SNILS { get; set; }
        public string MedPolis { get; set; }
        [Required]
        public LocalCity LocalCity { get; set; }
        public string Address { get; set; }
        public ushort? ApartmentNumber { get; set; }
        /// <summary>
        /// ФИО родителя1 
        /// </summary>
        [Required]
        public string Parent1 { get; set; }
        /// <summary>
        /// Номер телефона родителя1
        /// </summary>
        [Required]
        public string Parent1Phone { get; set; }
        /// <summary>
        /// ФИО родителя2 
        /// </summary>
        public string Parent2 { get; set; }
        /// <summary>
        /// Номер телефона родителя2
        /// </summary>
        public string Parent2Phone { get; set; }
        [Required]
        public Group Group1 { get; set; }
        public Group Group2 { get; set; }
        public Group Group3 { get; set; }
    }
}
