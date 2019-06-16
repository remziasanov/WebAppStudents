using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Документ студента
    /// </summary>
    public class Document : EntityBase<int>
    {
        public DocumentType DocumentType { get; set; }
        public string Number { get; set; }
        public string Seria { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    /// <summary>
    /// Тип документа
    /// </summary>
    public enum DocumentType
    {
        Passport,
        Svidetelstvo
    }
    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }
}
