using System;
using System.Collections.Generic;
using System.Text;
using WebApiContracts.DTO.Base;

namespace WebApiContracts.DTO
{
    public class DocumentDto : EntityDto<int>
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
