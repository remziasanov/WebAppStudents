using Client.LoadData;
using Client.ModelsUI;
using Client.ModelsUI.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        StudentUI student = new StudentUI();
        private void Form_DropDownOpened(object sender, EventArgs e)
        {
            for (int i = 1; i <= 11; i++)
            {
                form.Items.Add(i.ToString());
                this.form.DropDownOpened -= this.Form_DropDownOpened;
            }
        }
        private void Letter_DropDownOpened(object sender, EventArgs e)
        {
            for (int i = 'А'; i <= 'Я'; i++)
            {
                letter.Items.Add(Convert.ToChar(i));
            }
            this.letter.DropDownOpened -= this.Letter_DropDownOpened;
        }

        private async void Cities_DropDownOpened(object sender, EventArgs e)
        {
            cities.DropDownOpened -= this.Cities_DropDownOpened;
        }
        private async void Regions_DropDownOpened(object sender, EventArgs e)
        {
            List<RegionUI> _regions = await LoadDataFromJson<RegionUI>.LoadList("https://localhost:44357/api/region");
            if (_regions != null)
            {
                foreach (var item in _regions)
                {
                    regions.Items.Add(item.NameRegion);
                }
            }
            else
            {
                ErrorLabel.Content = "Сервер не запущен или нет связи с БД";
                ErrorLabel.Visibility = Visibility.Visible;
            }
            regions.DropDownOpened -= this.Regions_DropDownOpened;
        }

        private async Task LoadDepartments(ComboBox comboBox)
        {
            List<DepartmentUI> departments = await LoadDataFromJson<DepartmentUI>.LoadList("https://localhost:44357/api/department");
            if (departments != null)
            {
                foreach (var item in departments)
                {
                    comboBox.Items.Add(item.Title);
                }
            }
        }

        private async void DepartmentName1_DropDownOpened(object sender, EventArgs e)
        {
            await LoadDepartments(departmentName1);
            departmentName1.DropDownOpened -= this.DepartmentName1_DropDownOpened;
        }
        private async void DepartmentName2_DropDownOpened(object sender, EventArgs e)
        {
            await LoadDepartments(departmentName2);
            departmentName2.DropDownOpened -= this.DepartmentName2_DropDownOpened;
        }
        private async void DepartmentName3_DropDownOpened(object sender, EventArgs e)
        {
            await LoadDepartments(departmentName3);
            departmentName3.DropDownOpened -= this.DepartmentName3_DropDownOpened;
        }

        private async void Regions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cities.Items.Clear();
            string Value = (regions.SelectedIndex >= 0 ? regions.SelectedItem.ToString() : "");
            LoadSchools(Value);
            List<LocalCityUI> localcities = await LoadDataFromJson<LocalCityUI>.LoadList("https://localhost:44357/api/citylocal/" + Value);
            if (localcities != null)
            {
                foreach (var item in localcities)
                {
                    cities.Items.Add(item.CityName);
                }
            }
        }
        private List<GroupUI> MakeGroups(List<GroupUI> groups, ComboBox combo2, ComboBox combo3, ComboBox department1, ComboBox department2, ComboBox department3)
        {
            GroupUI group2UI = new GroupUI { Title = "" }, group3UI = new GroupUI { Title = "" };
            if (combo2.SelectedIndex >= 0 && department2.SelectedItem.ToString() == department1.SelectedItem.ToString())
                group2UI = groups.FirstOrDefault(x => x.Title == combo2.Text);
            if (combo3.SelectedIndex >= 0 && department3.SelectedItem.ToString() == department1.SelectedItem.ToString())
                group3UI = groups.FirstOrDefault(x => x.Title == combo3.Text);
            return groups.Where(x => x.Title != group2UI.Title && x.Title != group3UI.Title).ToList();
        }
        private async Task LoadGroups(ComboBox department, ComboBox group)
        {
            if (department != null & group != null)
            {
                group.Items.Clear();
                string Value = (department.SelectedIndex >= 0 ? department.SelectedItem.ToString() : "");
                List<GroupUI> Groups = await LoadDataFromJson<GroupUI>.LoadList("https://localhost:44357/api/group/" + Value);
                if (department.Name == "departmentName1")
                {
                    Groups = MakeGroups(Groups, groupName2, groupName3, departmentName1, departmentName2, departmentName3);
                }
                else if (department.Name == "departmentName2")
                {
                    Groups = MakeGroups(Groups, groupName1, groupName3, departmentName2, departmentName1, departmentName3);
                }
                else if (department.Name == "departmentName3")
                {
                    Groups = MakeGroups(Groups, groupName1, groupName2, departmentName3, departmentName1, departmentName2);
                }
                if (Groups != null)
                {
                    foreach (var item in Groups)
                    {
                        group.Items.Add(item.Title);
                    }
                }
            }
        }

        private async void DepartmentName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentName1.SelectedIndex >= 0)
            {
                groupName1.IsEditable = true;
                groupName1.Focusable = true;
                groupName1.IsHitTestVisible = true;
            }
            await LoadGroups(departmentName1, groupName1);
        }

        private async void DepartmentName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentName2.SelectedIndex >= 0)
            {
                groupName2.IsEditable = true;
                groupName2.Focusable = true;
                groupName2.IsHitTestVisible = true;
            }
            await LoadGroups(departmentName2, groupName2);
        }

        private async void DepartmentName3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentName3.SelectedIndex >= 0)
            {
                groupName3.IsEditable = true;
                groupName3.Focusable = true;
                groupName3.IsHitTestVisible = true;
            }
            await LoadGroups(departmentName3, groupName3);
        }
        private async void LoadSchools(string value)
        {
            schools.Items.Clear();
            List<SchoolUI> _schools = await LoadDataFromJson<SchoolUI>.LoadList("https://localhost:44357/api/school/" + value);
            if (_schools != null)
            {
                foreach (var school in _schools)
                {
                    schools.Items.Add(school.Title);
                }
            }
        }
        private async void Show_all_schools_Checked(object sender, RoutedEventArgs e)
        {
            LoadSchools("");
        }
        private async void Show_all_schools_Unchecked(object sender, RoutedEventArgs e)
        {
            string Value = (regions.SelectedIndex >= 0 ? regions.SelectedItem.ToString() : "");
            if (Value != "") LoadSchools(Value);
            else schools.Items.Clear();
        }


        private async void BtnSaveStudent_Click(object sender, RoutedEventArgs e)
        {
            string currentcity = cities.SelectedItem.ToString();
            if (currentcity != null)
                student.LocalCity = await LoadDataFromJson<LocalCityUI>.LoadModel("https://localhost:44357/api/citylocal/" + currentcity);
            student.Name = name.Text;
            student.Surname = surname.Text;
            student.Fathername = fathername.Text;
            student.Email = email.Text;
            student.Phone = phone.Text;
            student.Grade = form.Text + letter.Text;
            student.SNILS = snils.Text;
            student.MedPolis = polis.Text;
            student.Address = address.Text;
            string gr1 = groupName1.SelectedItem.ToString();
            student.Group1 = await LoadDataFromJson<GroupUI>.LoadModel("https://localhost:44357/api/group/" + groupName1.SelectedItem.ToString());


        }
        private async void GroupName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentName2.IsEditable = true;
            departmentName2.Focusable = true;
            departmentName2.IsHitTestVisible = true;
            GroupsRemove(groupName2, groupName1);
            GroupsRemove(groupName3, groupName1);
        }
        private async void GroupName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentName3.IsEditable = true;
            departmentName3.Focusable = true;
            departmentName3.IsHitTestVisible = true;
            GroupsRemove(groupName1, groupName2);
            GroupsRemove(groupName3, groupName2);
        }
        private async void GroupName3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupsRemove(groupName2, groupName3);
            GroupsRemove(groupName1, groupName3);
        }
        private async void GroupsRemove(ComboBox groupName1, ComboBox groupName2)
        {
            if (groupName2.SelectedIndex >= 0)
            {
                for (int i = 0; i < groupName1.Items.Count; i++)
                {
                    string groupName = groupName1.Items.GetItemAt(i).ToString();
                    string selectedItem = groupName2.SelectedItem.ToString();
                    if (groupName == selectedItem)
                    {
                        groupName1.Items.RemoveAt(i);
                    }
                }
            }
        }
    }
}
