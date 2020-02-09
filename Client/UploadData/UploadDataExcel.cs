using Client.ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Client.UploadData
{
    public class UploadDataExcel
    {
        private const string numberFirstRow = "№";
        private const string nameFirstRow = "Имя";
        private const string surnameFirstRow = "Фамилия";
        private const string fathernameFirstRow = "Отчество";
        private const string emailFirstRow = "Email";
        private const string phoneFirstRow = "Телефон";
        private const string sNILSFirstRow = "СНИЛС";
        private const string medPolisFirstRow = "Полис";
        private const string genderFirstRow = "Пол";
        private const string birthFirstRow = "Дата рождения";
        private const string schoolFirstRow = "Школа";
        private const string localCityFirstRow = "Город";
        private const string addressFirstRow = "Адрес";
        private const string apartmentNumberFirstRow = "Номер квартиры";
        private const string gradeFirstRow = "Класс";
        private const string documentTypeFirstRow = "Тип документа";
        private const string seriaFirstRow = "Серия";
        private const string nomerFirstRow = "Номер";
        private const string parent1FirstRow = "ФИО первого родителя";
        private const string parent1PhoneFirstRow = "Телефон первого родителя";
        private const string parent2FirstRow = "ФИО второго родителя";
        private const string parent2PhoneFirstRow = "Телефон второго родителя";
        private const string group1FirstRow = "Первый кружок";
        private const string group2FirstRow = "Второй кружок";
        private const string group3FirstRow = "Третий кружок";

        public async Task UploadExcel(List<StudentUI> students, string savepath)
        {
            Excel.Application ex = new Excel.Application
            {
                Visible = false,
                SheetsInNewWorkbook = 1
            };
            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            //Название листа (вкладки снизу)
            sheet.Name = "Название группы";
            //Пример заполнения ячеек

            Excel.Range er = sheet.get_Range("B:ZZ", System.Type.Missing);
            er.EntireColumn.ColumnWidth = 18;
            var columnHeadingsRange = sheet.Range[
                 sheet.Cells[1, "A"],
                 sheet.Cells[1, "AB"]];
            var rowHeadingRange = sheet.Range[
                 sheet.Cells[2, "A"],
                 sheet.Cells[students.Count + 1, "A"]];
            rowHeadingRange.Interior.Color = Excel.XlRgbColor.rgbForestGreen;

            rowHeadingRange.Font.Color = Excel.XlRgbColor.rgbWhite;

            columnHeadingsRange.Interior.Color = Excel.XlRgbColor.rgbForestGreen;

            columnHeadingsRange.Font.Color = Excel.XlRgbColor.rgbWhite;
            sheet.Rows[1].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            sheet.Columns[1].ColumnWidth = 7;
            sheet.Columns[9].ColumnWidth = 5;
            sheet.Columns[23].ColumnWidth = 25;
            sheet.Columns[25].ColumnWidth = 25;
            sheet.Columns[27].ColumnWidth = 25;
            var u = Task.Run(() =>
            {
                sheet.Cells[1, 1] = numberFirstRow;
                sheet.Cells[1, 2] = nameFirstRow;
                sheet.Cells[1, 3] = surnameFirstRow;
                sheet.Cells[1, 4] = fathernameFirstRow;
                sheet.Cells[1, 5] = emailFirstRow;
                sheet.Cells[1, 6] = phoneFirstRow;
                sheet.Cells[1, 7] = sNILSFirstRow;
                sheet.Cells[1, 8] = medPolisFirstRow;
                sheet.Cells[1, 9] = genderFirstRow;
                sheet.Cells[1, 10] = birthFirstRow;
                sheet.Cells[1, 11] = schoolFirstRow;
                sheet.Cells[1, 12] = localCityFirstRow;
                sheet.Cells[1, 13] = addressFirstRow;
                sheet.Cells[1, 14] = apartmentNumberFirstRow;
                sheet.Cells[1, 15] = gradeFirstRow;
                sheet.Cells[1, 16] = documentTypeFirstRow;
                sheet.Cells[1, 17] = seriaFirstRow;
                sheet.Cells[1, 18] = nomerFirstRow;
                sheet.Cells[1, 19] = parent1FirstRow;
                sheet.Cells[1, 20] = parent1PhoneFirstRow;
                sheet.Cells[1, 21] = parent2FirstRow;
                sheet.Cells[1, 22] = parent2PhoneFirstRow;
                sheet.Cells[1, 23] = group1FirstRow;
                sheet.Cells[1, 24] = group2FirstRow;
                sheet.Cells[1, 25] = group3FirstRow;
            });
            int begin = 1, end = 1;
            int loadParts = 4;
            int lenStudents = students.Count / loadParts;
            var firstPart = Task.Run(() => WriteDataToExcel(students, sheet, 1, lenStudents));
            var secondPart = Task.Run(() => WriteDataToExcel(students, sheet, lenStudents + 1, lenStudents * 2));
            var thirdPart = Task.Run(() => WriteDataToExcel(students, sheet, lenStudents * 2 + 1, lenStudents * 3));
            var fourthPart = Task.Run(() => WriteDataToExcel(students, sheet, lenStudents * 3 + 1, students.Count() + 1));
            begin = end + 1;
            u.Wait();
            firstPart.Wait();
            secondPart.Wait();
            thirdPart.Wait();
            fourthPart.Wait();
            sheet.SaveAs(@savepath);
        }

        private static void WriteDataToExcel(List<StudentUI> students, Excel.Worksheet sheet, int begin, int end)
        {
            if (begin == 1) begin++;
            for (int i = begin; i <= end; i++)
            {
                sheet.Cells[i, 1] = (i - 1).ToString();
                sheet.Cells[i, 2] = students[i - 2].Name;
                sheet.Cells[i, 3] = students[i - 2].Surname;
                sheet.Cells[i, 4] = students[i - 2].Fathername;
                sheet.Cells[i, 5] = students[i - 2].Email;
                sheet.Cells[i, 6] = students[i - 2].Phone;
                sheet.Cells[i, 7] = students[i - 2].SNILS;
                sheet.Cells[i, 8] = students[i - 2].MedPolis;
                sheet.Cells[i, 9] = students[i - 2].MainDocument.Gender == Gender.Male ? "М" : "Ж";
                sheet.Cells[i, 10] = students[i - 2].MainDocument.DateOfBirth.ToString();
                sheet.Cells[i, 11] = students[i - 2].LocalCity.CityName;
                sheet.Cells[i, 12] = students[i - 2].School.Title;
                sheet.Cells[i, 13] = students[i - 2].Address;
                sheet.Cells[i, 14] = students[i - 2].ApartmentNumber.ToString();
                sheet.Cells[i, 15] = students[i - 2].Grade;
                sheet.Cells[i, 16] = students[i - 2].MainDocument.DocumentType.ToString();
                sheet.Cells[i, 17] = students[i - 2].MainDocument.Seria;
                sheet.Cells[i, 18] = students[i - 2].MainDocument.Number;
                sheet.Cells[i, 19] = students[i - 2].Parent1;
                sheet.Cells[i, 20] = students[i - 2].Parent1Phone;
                sheet.Cells[i, 21] = students[i - 2].Parent2;
                sheet.Cells[i, 22] = students[i - 2].Parent2Phone;
                sheet.Cells[i, 23] = students[i - 2].Group1.Title;
                if (students[i - 2].Group2 != null)
                {
                    sheet.Cells[i, 24] = students[i - 2].Group2.Title;
                    if(students[i - 2].Group3 != null)
                      sheet.Cells[i, 25] = students[i - 2].Group3.Title;
                }
            }
        }
    }
}
