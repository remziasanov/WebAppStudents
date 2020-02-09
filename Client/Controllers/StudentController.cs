using Client.ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.LoadData;
using System.Windows.Controls;
using Client.ModelsUI.Base;
using System.Reflection;
using System.Configuration;
using System.Data;

namespace Client.Controllers
{
    class StudentController
    {
        public string getGroupsLink { get => ConfigurationSettings.AppSettings["GroupGetNameLink"].ToString(); }
        public string groupsGetLink { get => ConfigurationSettings.AppSettings["GroupsLink"].ToString(); }
        public string regionLink { get => ConfigurationSettings.AppSettings["RegionGetLink"].ToString(); }
        public string departmentsLink { get => ConfigurationSettings.AppSettings["DepartmentGetLink"].ToString(); }
        public string localCitiesLink { get => ConfigurationSettings.AppSettings["CityLocalGetLink"].ToString(); }
        public string schoolsLink { get => ConfigurationSettings.AppSettings["SchoolGetLink"].ToString(); }
        public string studentFilterLink { get => ConfigurationSettings.AppSettings["StudentsFilterLink"].ToString(); }
        public string studentsGetLink { get => ConfigurationSettings.AppSettings["StudentsGetLink"].ToString(); }

        public async Task<List<T>> ObjectLoad<T>(string url) where T : EntityBaseUI<int>
        {
            return await new LoadDataFromJson<T>().LoadList(url);
        }
        public async Task LoadComboBox<T>(ComboBox combobox, List<T> objects, string property) where T : EntityBaseUI<int>
        {
            combobox.Items.Clear();
            if (objects != null && objects.Count > 0)
            {
                PropertyInfo propertySearch = null;
                foreach (PropertyInfo propertyInfo in objects[0].GetType().GetProperties())
                {
                    if (propertyInfo.Name.ToLower() == property.ToLower())
                    {
                        propertySearch = propertyInfo;
                        break;
                    }
                }
                List<string> comboItems = new List<string>();
                foreach (var item in objects)
                {
                    comboItems.Add(propertySearch.GetValue(item).ToString());
                }
                foreach (var item in comboItems.OrderBy(x=>x))
                {
                    combobox.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Loading not selected groups
        /// </summary>
        /// <param name="groups">Group list</param>
        /// <param name="combo2">First unselected combobox</param>
        /// <param name="combo3">Second unselected combobox</param>
        /// <param name="department1">First combobox for department list</param>
        /// <param name="department2">Second combobox for department list</param>
        /// <param name="department3">Third combobox for department list</param>
        /// <returns></returns>
        public List<GroupUI> LoadNotExistingGroups(List<GroupUI> groups, ComboBox combo2, ComboBox combo3, ComboBox department1,
           ComboBox department2, ComboBox department3)
        {
            GroupUI group2UI = new GroupUI { Title = "" }, group3UI = new GroupUI { Title = "" };
            if (combo2.SelectedIndex >= 0 && department2.SelectedItem.ToString() == department1.SelectedItem.ToString())
                group2UI = groups.FirstOrDefault(x => x.Title == combo2.Text);
            if (combo3.SelectedIndex >= 0 && department3.SelectedItem.ToString() == department1.SelectedItem.ToString())
                group3UI = groups.FirstOrDefault(x => x.Title == combo3.Text);
            return groups.Where(x => x.Title != group2UI.Title && x.Title != group3UI.Title).ToList();
        }

        /// <summary>
        /// Loading groups
        /// </summary>
        /// <param name="Groups">Group list</param>
        /// <param name="departments">Array of comboboxes of department lists</param>
        /// <param name="groups">Array of comboboxes of group lists</param>
        /// <returns></returns>
        public async Task LoadGroups(List<GroupUI> Groups, ComboBox[] departments, ComboBox[] groups, int index)
        {
            ComboBox LoadGroup;
            if (index == 0)
            {
                Groups = LoadNotExistingGroups(Groups, groups[1], groups[2], departments[0], departments[1], departments[2]);
                LoadGroup = groups[0];
            }
            else if (index == 1)
            {
                Groups = LoadNotExistingGroups(Groups, groups[0], groups[2], departments[1], departments[0], departments[2]);
                LoadGroup = groups[1];
            }
            else
            {
                Groups = LoadNotExistingGroups(Groups, groups[0], groups[1], departments[2], departments[0], departments[1]);
                LoadGroup = groups[2];
            }
            LoadGroup.Items.Clear();
            if (Groups != null)
            {
                foreach (var item in Groups)
                {
                    LoadGroup.Items.Add(item.Title);
                }
            }
        }
        /// <summary>
        /// Getting groups
        /// </summary> 
        /// <param name="department">Combobox for department list</param>
        /// <param name="group">Combobox for group list</param>
        /// <returns></returns>
        public async Task<List<GroupUI>> GetGroupsByComboBoxDepartment(ComboBox department)
        {
            LoadDataFromJson<GroupUI> groupsJson = new LoadDataFromJson<GroupUI>();
            string value = (department.SelectedIndex >= 0 ? department.SelectedItem.ToString() : "");
            List<GroupUI> groups = await groupsJson.LoadList(groupsGetLink + value);
            return groups;
        }

        public void LoadAllGroupsToComboBox(ComboBox group, List<GroupUI> groups)
        {
            group.Items.Clear();
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    group.Items.Add(item.Title);
                }
            }
        }

        public async Task LoadAllGroupsToComboBox(ComboBox group)
        {
            LoadDataFromJson<GroupUI> groupsJson = new LoadDataFromJson<GroupUI>();
            List<GroupUI> Groups = await groupsJson.LoadList(groupsGetLink);
            group.Items.Clear();
            if (Groups != null)
            {
                foreach (var item in Groups)
                {
                    group.Items.Add(item.Title);
                }
            }
        }

        public void HandlePhone(TextBox phoneBox)
        {
            string phone = phoneBox.Text;
            if (phone.Length > 2 && phone.Length < 7 || phone.Length > 6 && phone.Length < 12
                || phone.Length > 11 && phone.Length < 14 || phone.Length > 13)
            {
                string digit = Convert.ToString(phone[phone.Length - 1]);
                bool isNumeric = int.TryParse(digit, out int n);
                if (!isNumeric)
                {
                    phone = phone.Remove(phone.Length - 1);
                    phoneBox.Text = phone.ToString();
                }
            }
            if (phone.Length == 6)
            {
                phoneBox.Text += ")-";
            }
            if (phone.Length == 11)
            {
                phoneBox.Text += "-";
            }
            if (phone.Length == 14)
            {
                phoneBox.Text += "-";
            }
            if (phone.Length > 17)
            {
                phoneBox.Text = phoneBox.Text.Substring(0, 17);
            }
        }

        public async Task MakeDataTable(ComboBox department, ComboBox group, ComboBox teacher)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("№");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Отчество");
            dt.Columns.Add("Школа");
            dt.Columns.Add("Класс");
            dt.Columns.Add("Родитель 1");
            dt.Columns.Add("Телефон родителя 1");
            LoadDataFromJson<StudentUI> studentsJson = new LoadDataFromJson<StudentUI>();
            List<StudentUI> students = await studentsJson.LoadList(studentsGetLink);
        }

        public async Task<List<StudentUI>> SortStudentsList(List<StudentUI> studentsMain, ComboBox department, ComboBox group, ComboBox teacher)
        {
            object departmentValue = department.SelectedItem;
            object groupValue = group.SelectedItem;
            object teacherValue = teacher.SelectedItem;
            LoadDataFromJson<DepartmentUI> departmentsJson = new LoadDataFromJson<DepartmentUI>();
            List<DepartmentUI> departments = await departmentsJson.LoadList(departmentsLink);
            if (departmentValue != null)
            {
                if (departmentValue.ToString() != "Все")
                {
                    DepartmentUI departmentSearch = departments.Where(x => x.Title == departmentValue.ToString()).FirstOrDefault();
                    studentsMain = studentsMain.Where(x => x.Group1.DepartmentId == departmentSearch.Id
                    || (x.Group2 != null ? x.Group2.DepartmentId : 0) == departmentSearch.Id
                    || (x.Group3 != null ? x.Group3.DepartmentId : 0) == departmentSearch.Id).ToList();
                }
            }
            if (groupValue != null)
            {
                studentsMain = studentsMain.Where(x => x.Group1.Title == groupValue.ToString()
                || x.Group2.Title == groupValue.ToString()
                || x.Group3.Title == groupValue.ToString()).ToList();
            }
            if (teacherValue != null)
            {
                studentsMain = studentsMain.Where(x => x.Group1.Teacher == teacherValue.ToString()
                || x.Group2.Teacher == teacherValue.ToString()
                || x.Group3.Teacher == teacherValue.ToString()).ToList(); 
            }
            return studentsMain;
        }
        
        public List<StudentUI> SortStudentsByGroups(List<StudentUI> students, string groupname)
        {
           return students.Where(x => x.Group1.Title == groupname
                    || (x.Group2 != null ? x.Group2.Title : "") == groupname
                    || (x.Group3 != null ? x.Group3.Title : "") == groupname).ToList();
        }
    }
}