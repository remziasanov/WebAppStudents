using Client.ModelsUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ModelsUI
{
    /// <summary>
    /// Документ студента
    /// </summary>
    public class DocumentUI : EntityBaseUI<int>
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
