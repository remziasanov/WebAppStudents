using Client.LoadData;
using Client.ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.UploadData;
using System.Reflection;
using System.Data;
using System.Windows.Media;
using System.Windows.Markup;
using System.IO;
using System.Xml;
using Client.Controllers;
using System.Configuration;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Key[] digitKeys = new Key[]
        {
            Key.D0, Key.D1, Key.D2, Key.D3, Key.D4,
            Key.D5, Key.D6, Key.D7, Key.D8, Key.D9,
            Key.NumPad0, Key.NumPad1, Key.NumPad2,
            Key.NumPad3, Key.NumPad4, Key.NumPad5,
            Key.NumPad6, Key.NumPad7, Key.NumPad8,
            Key.NumPad9,
        };
        new private enum WindowStyle
        {
            Dark,
            Light
        };
        LoadDataFromJson<StudentUI> studentsJson;
        LoadDataFromJson<DepartmentUI> departmentsJson;
        LoadDataFromJson<LocalCityUI> citiesJson;
        LoadDataFromJson<RegionUI> regionsJson;
        LoadDataFromJson<SchoolUI> schoolsJson;
        LoadDataFromJson<GroupUI> groupsJson;
        LoadDataFromJson<DocumentUI> documentsJson;
        List<StudentUI> studentsMain;
        bool isLoadEdit = false;
        WindowStyle windowStyle = WindowStyle.Light;
        // all url on App.config
        const string all_Departments_selected = "Все";
        string getGroupsLink = ConfigurationSettings.AppSettings["GroupGetNameLink"].ToString();
        string groupsGetLink = ConfigurationSettings.AppSettings["GroupsLink"].ToString();
        string groupsGetNameLink = ConfigurationSettings.AppSettings["GroupGetNameLink"].ToString();
        string regionLink = ConfigurationSettings.AppSettings["RegionGetLink"].ToString();
        string departmentsLink = ConfigurationSettings.AppSettings["DepartmentGetLink"].ToString();
        string localCitiesLink = ConfigurationSettings.AppSettings["CityLocalGetLink"].ToString();
        string schoolsLink = ConfigurationSettings.AppSettings["SchoolGetLink"].ToString();
        string studentFilterLink = ConfigurationSettings.AppSettings["StudentsFilterLink"].ToString();
        string studentsGetLink = ConfigurationSettings.AppSettings["StudentsGetLink"].ToString();

        public static readonly DependencyProperty Phone =
        DependencyProperty.RegisterAttached("Phone", typeof(string), typeof(Window), new PropertyMetadata(default(string)));
        public static void SetPhone(UIElement element, string value)
        {
            element.SetValue(Phone, value);
        }

        public static string GetPhone(UIElement element)
        {
            return (string)element.GetValue(Phone);
        }
        public MainWindow()
        {
            InitializeComponent();

            studentsJson = new LoadDataFromJson<StudentUI>();
            departmentsJson = new LoadDataFromJson<DepartmentUI>();
            citiesJson = new LoadDataFromJson<LocalCityUI>();
            regionsJson = new LoadDataFromJson<RegionUI>();
            schoolsJson = new LoadDataFromJson<SchoolUI>();
            groupsJson = new LoadDataFromJson<GroupUI>();
            documentsJson = new LoadDataFromJson<DocumentUI>();
            SetPhone(parent1Phone, "");
        }
        StudentUI student = new StudentUI();

        public string StudentFilterLink { get => studentFilterLink; set => studentFilterLink = value; }

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
        private void Cities_DropDownOpened(object sender, EventArgs e)
        {
            cities.DropDownOpened -= this.Cities_DropDownOpened;
        }
        private async void Regions_DropDownOpened(object sender, EventArgs e)
        {
            await new StudentController().LoadComboBox(regions, await new
                StudentController().ObjectLoad<RegionUI>(regionLink), "NameRegion");
            regions.DropDownOpened -= this.Regions_DropDownOpened;
        }
        private async Task LoadDepartments(ComboBox comboBox)
        {
            await new StudentController().LoadComboBox(comboBox, await new
                StudentController().ObjectLoad<DepartmentUI>(departmentsLink), "Title");
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

            await new StudentController().LoadComboBox(cities, await new
                StudentController().ObjectLoad<LocalCityUI>(localCitiesLink + Value), "CityName");

            cities.IsEditable = true;
            cities.Focusable = true;
            cities.IsHitTestVisible = true;
        }

        public async Task HandleDepartmentChange(ComboBox department, ComboBox group)
        {
            group.IsEditable = true;
            group.Focusable = true;
            group.IsHitTestVisible = true;
            List<GroupUI> groups = await new StudentController().GetGroupsByComboBoxDepartment(department);
            await new StudentController().LoadGroups(groups, new ComboBox[] { departmentName1, departmentName2, departmentName3 },
                new ComboBox[] { groupName1, groupName2, groupName3 },
                (department.Name == "departmentName1" ? 0 : department.Name == "departmentName2" ? 1 : 2));
        }


        private async void DepartmentName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await HandleDepartmentChange(departmentName1, groupName1);
        }

        private async void DepartmentName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await HandleDepartmentChange(departmentName2, groupName2);
        }

        private async void DepartmentName3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await HandleDepartmentChange(departmentName3, groupName3);
        }
        private async void LoadSchools(string Value)
        {
            await new StudentController().LoadComboBox(schools, await new
                StudentController().ObjectLoad<SchoolUI>(schoolsLink + Value), "Title");
        }
        private async Task LoadTeachers(ComboBox teachersBox)
        {
            List<StudentUI> students = await studentsJson.LoadList(studentsGetLink);
            List<string> teachers = new List<string>();
            foreach (var student in students)
            {
                if (student.Group1 != null)
                {
                    if (!teachers.Contains(student.Group1.Teacher))
                        teachers.Add(student.Group1.Teacher);
                    if (student.Group2 != null)
                    {
                        if (!teachers.Contains(student.Group2.Teacher))
                            teachers.Add(student.Group2.Teacher);
                        if (student.Group3 != null)
                            if (!teachers.Contains(student.Group3.Teacher))
                                teachers.Add(student.Group3.Teacher);
                    }
                }
            }
            foreach (var teacher in teachers)
            {
                teachersBox.Items.Add(teacher);
            }
        }
        private void Show_all_schools_Checked(object sender, RoutedEventArgs e)
        {
            LoadSchools("");
        }
        private void Show_all_schools_Unchecked(object sender, RoutedEventArgs e)
        {
            string Value = (regions.SelectedIndex >= 0 ? regions.SelectedItem.ToString() : "");
            if (Value != "") LoadSchools(Value);
            else schools.Items.Clear();
        }
        private bool CheckControl(Control ctrl, string type = "")
        {
            SolidColorBrush red = Brushes.Red;
            SolidColorBrush black = Brushes.Black;
            Regex phoneRegex = new
                Regex(@"^[+][7-8][(][1-9][1-9][1-9][)][-]?[0-9][0-9][0-9][-]?[0-9][0-9][-]?[0-9][0-9]$");
            if (ctrl.GetType() == typeof(TextBox))
            {
                if (String.IsNullOrEmpty((ctrl as TextBox).Text))
                {
                    (ctrl as TextBox).BorderBrush = red;
                    return false;
                }
                if (type == "phone" && !phoneRegex.IsMatch((ctrl as TextBox).Text))
                {
                    (ctrl as TextBox).BorderBrush = red;
                    return false;
                }
                (ctrl as TextBox).BorderBrush = black;
            }
            if (ctrl.GetType() == typeof(ComboBox))
            {
                if ((ctrl as ComboBox).SelectedIndex == -1)
                {
                    (ctrl as ComboBox).BorderBrush = red;
                    return false;
                }
                (ctrl as ComboBox).BorderBrush = black;
            }
            if (ctrl.GetType() == typeof(DatePicker))
            {
                if (String.IsNullOrEmpty((ctrl as DatePicker).Text))
                {
                    (ctrl as DatePicker).BorderBrush = red;
                    return false;
                }
                (ctrl as DatePicker).BorderBrush = black;
            }
            return true;
        }
        private bool CheckRadioButton(RadioButton radio1, RadioButton radio2)
        {
            SolidColorBrush red = Brushes.Red;
            SolidColorBrush black = Brushes.Black;
            bool? value1 = radio1.IsChecked;
            bool? value2 = radio2.IsChecked;
            if (!(value1.HasValue && value1.Value) &&
                !(value2.HasValue && value2.Value))
            {
                radio1.BorderBrush = red;
                radio2.BorderBrush = red;
                return false;
            }
            else
            {
                radio1.BorderBrush = black;
                radio2.BorderBrush = black;
            }
            return true;
        }
        private async void SwitchError(string error = "")
        {
            if (error != "")
            {
                ErrorLabel.Content = error;
                ErrorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorLabel.Content = "";
                ErrorLabel.Visibility = Visibility.Hidden;
            }
        }
        private async void BtnSaveStudent_Click(object sender, RoutedEventArgs e)
        {
            List<bool> checkControls = new List<bool>();
            checkControls.Add(CheckControl(name));
            checkControls.Add(CheckControl(surname));
            checkControls.Add(CheckControl(email));
            checkControls.Add(CheckControl(phone, "phone"));
            checkControls.Add(CheckControl(form));
            checkControls.Add(CheckControl(letter));
            checkControls.Add(CheckControl(snils));
            checkControls.Add(CheckControl(polis));
            checkControls.Add(CheckControl(regions));
            checkControls.Add(CheckControl(cities));
            checkControls.Add(CheckControl(address));
            checkControls.Add(CheckControl(apartment));
            if (short.TryParse(apartment.Text, out short res))
            {
                apartment.BorderBrush = Brushes.Black;
                checkControls.Add(true);
            }
            else
            {
                apartment.BorderBrush = Brushes.Red;
                checkControls.Add(false);
            }
            checkControls.Add(CheckControl(date));
            checkControls.Add(CheckControl(schools));
            checkControls.Add(CheckControl(regions));
            checkControls.Add(CheckControl(seria));
            checkControls.Add(CheckControl(number));
            checkControls.Add(CheckControl(departmentName1));
            checkControls.Add(CheckControl(groupName1));
            checkControls.Add(CheckControl(parent1Name));
            checkControls.Add(CheckControl(parent1Phone, "phone"));
            checkControls.Add(CheckRadioButton(passport, svidetelstvo));
            checkControls.Add(CheckRadioButton(male, female));
            if (checkControls.Contains(false))
            {
                SwitchError("Заполнены не все поля");
                return;
            }
            else SwitchError();

            LocalCityUI localCityUI = await citiesJson.LoadModel(localCitiesLink + "getbytitle/" + cities.SelectedItem);
            SchoolUI schoolUI = await schoolsJson.LoadModel(schoolsLink + "get/" + schools.SelectedValue);
            GroupUI g1;
            GroupUI g2;
            GroupUI g3;
            g1 = await groupsJson.LoadModel(groupsGetNameLink + groupName1.SelectedItem);
            if (groupName2.SelectedIndex != -1)
            {
                g2 = await groupsJson.LoadModel(groupsGetNameLink + groupName2.SelectedItem);
                if (groupName3.SelectedIndex != -1)
                {
                    g3 = await groupsJson.LoadModel(groupsGetNameLink + groupName3.SelectedItem);
                }
                else
                {
                    g3 = null;
                }
            }
            else
            {
                g2 = null;
                g3 = null;
            }
            bool? passporti = passport.IsChecked;
            bool? sex = male.IsChecked;
            StudentUI student = new StudentUI()
            {
                Name = name.Text,
                Surname = surname.Text,
                Fathername = fathername.Text,
                Email = email.Text,
                Phone = phone.Text,
                LocalCity = localCityUI,
                Address = address.Text,
                School = schoolUI,
                ApartmentNumber = Convert.ToByte(apartment.Text),
                Grade = form.Text + letter.Text,
                MainDocument = new DocumentUI
                {
                    DocumentType = (passporti.HasValue &&
                passporti.Value ? DocumentType.Passport : DocumentType.Svidetelstvo),
                    Gender = (sex.HasValue && sex.Value ? Gender.Male : Gender.Female),
                    DateOfBirth = Convert.ToDateTime(date.Text),
                    Number = number.Text,
                    Seria = seria.Text,
                },
                MedPolis = polis.Text,
                SNILS = snils.Text,
                Group1 = g1,
                Group2 = g2,
                Group3 = g3,
                Parent1 = parent1Name.Text,
                Parent1Phone = parent1Phone.Text,
                Parent2 = parent2Name.Text,
                Parent2Phone = parent2Phone.Text
            };
            HttpResponseMessage mes = await studentsJson.Add(studentsGetLink, student);
        }
        private void GroupName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentName2.IsEditable = true;
            departmentName2.Focusable = true;
            departmentName2.IsHitTestVisible = true;
            GroupsRemove(groupName2, groupName1);
            GroupsRemove(groupName3, groupName1);
        }
        private void GroupName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departmentName3.IsEditable = true;
            departmentName3.Focusable = true;
            departmentName3.IsHitTestVisible = true;
            GroupsRemove(groupName1, groupName2);
            GroupsRemove(groupName3, groupName2);
        }
        private void GroupName3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupsRemove(groupName2, groupName3);
            GroupsRemove(groupName1, groupName3);
        }
        private void GroupsRemove(ComboBox groupName1, ComboBox groupName2)
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

        private async void ChangePhone(object sender)
        {
            if ((sender as TextBox).Text.Length > 17)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 17);
                string textPhone = GetPhone((sender as TextBox));
                if (textPhone.Length > 10) SetPhone((sender as TextBox),
                    textPhone.Substring(0, 10));
            }
            else
            {
                SetPhone((sender as TextBox), GetPhone((sender as TextBox))
                    + (sender as TextBox).Text.Last());
            }
        }

        private void PlusSevenPhoneCheck(TextBox textBox)
        {
            if (textBox.Text.Length < 3 || textBox.Text.Substring(0, 3) != "+7(")
            {
                textBox.Text = "+7(";
                textBox.CaretIndex = 3;
            }
            //if (textBox.CaretIndex < textBox.Text.Length)
            //    textBox.CaretIndex = textBox.Text.Length;
        }

        private void Parent1Phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            PlusSevenPhoneCheck(parent1Phone);
        }

        private void Parent2Phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            PlusSevenPhoneCheck(parent2Phone);
        }

        private void Phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            PlusSevenPhoneCheck(phone);
        }

        private async void Cities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cities.SelectedItem != null)
            {
                string currentcity = cities.SelectedItem.ToString();
                student.LocalCity = await citiesJson.LoadModel(
                   localCitiesLink + "getbytitle/" + currentcity);
            }
        }

        private string CorrectPhone(string phone, TextBox textBox, bool mode = false)
        {
            return phone;
            //if (!mode)
            //{
            //    string realPhone = GetPhone(textBox);
            //    int lengthi = realPhone.Length;
            //    //+7(978)-123-12-23
            //    if (lengthi != 8 && lengthi != 9 && lengthi != 12 && lengthi != 14) {
            //        SetPhone(textBox, realPhone.Substring(realPhone.Length - 1));
            //    }
            //}
            //int len = GetPhone(textBox).Length;
            //string mask = "+7(###)-###-##-##";
            //if (len == 0) mask = "+7(";
            //if (len == 1) mask = "+7(#";
            //if (len == 2) mask = "+7(##";
            //if (len == 3) mask = "+7(###";
            //if (len == 4) mask = "+7(###)-#";
            //if (len == 5) mask = "+7(###)-##";
            //if (len == 6) mask = "+7(###)-###";
            //if (len == 7) mask = "+7(###)-###-#";
            //if (len == 8) mask = "+7(###)-###-##";
            //if (len == 9) mask = "+7(###)-###-##-#";
            //if (len == 10) mask = "+7(###)-###-##-##";
            //phone = Convert.ToUInt64(GetPhone(textBox)).ToString(mask);
            //return phone;
        }

        private void Parent1Phone_KeyUp(object sender, KeyEventArgs e)
        {
            //string phone = parent1Phone.Text;
            //if (e.Key == Key.Back)
            //{
            //    parent1Phone.Text = CorrectPhone(phone, parent1Phone);
            //}
            //else if (digitKeys.Contains(e.Key))
            //{
            //    ChangePhone(parent1Phone);
            //    parent1Phone.Text = CorrectPhone(phone, parent1Phone, true);
            //}
        }

        private async void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabs.SelectedIndex == 1)
            {
                if (all_students_departments.Items.Count == 0)
                {
                    await LoadTeachers(all_students_teachers);
                    await LoadDepartments(all_students_departments);
                    all_students_departments.Items.Add("Все");
                    all_students_departments.SelectionChanged += All_students_departments_SelectionChanged;
                    all_students_groups.SelectionChanged += All_students_groups_SelectionChanged;
                    all_students_teachers.SelectionChanged += All_students_teachers_SelectionChanged;
                }
            }
        }
        private void LoadEditTab()
        {
            if (!isLoadEdit)
            {
                isLoadEdit = true;
                string gridXaml = XamlWriter.Save(templateGrid);
                StringReader stringReader = new StringReader(gridXaml);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Grid gridEdit = (Grid)XamlReader.Load(xmlReader);
                editGrid.Children.Add(gridEdit);
                Grid.SetRow(gridEdit, 0);
                Button editButton = new Button
                {
                    Content = "Редактировать",
                    Name = "btnEditStudent",
                    Width = 132,
                    Height = 32,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(10)
                };
                editButton.Click += BtnEditStudent_Click;
                Grid.SetRow(editButton, 1);
            }
        }

        private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task LoadAllStudents(List<StudentUI> students)
        {
            if (students != null)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Surname");
                dataTable.Columns.Add("Fathername");
                dataTable.Columns.Add("Grade");
                dataTable.Columns.Add("School");
                dataTable.Columns.Add("Parent");
                dataTable.Columns.Add("Parent_phone");
                dataTable.Columns.Add("Groups");
                int count = 0;
                foreach (var student in students)
                {
                    count++;
                    string[] row = new string[9];
                    row[0] = count.ToString();
                    row[1] = student.Name.ToString();
                    row[2] = student.Surname.ToString();
                    row[3] = student.Fathername.ToString();
                    row[4] = student.School.Title.ToString();
                    row[5] = student.Grade.ToString();
                    row[6] = student.Parent1.ToString();
                    row[7] = student.Parent1Phone.ToString();
                    if (student.Group1 != null) row[8] += student.Group1.Title;
                    if (student.Group2 != null) row[8] += "; " + student.Group2.Title;
                    if (student.Group3 != null) row[8] += "; " + student.Group3.Title;
                    dataTable.Rows.Add(row);
                }
                students_list.ItemsSource = dataTable.DefaultView;
            }
        }

        private async void All_students_teachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selected = all_students_teachers.SelectedItem;
            if (selected != null)
            {
                studentsMain = await studentsJson.LoadList(StudentFilterLink + $"teacher/{selected.ToString()}");
                await LoadAllStudents(studentsMain);
            }
        }

        private async void All_students_groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentsMain != null)
            {
                if (studentsMain.Count > 0)
                {
                    object selectedComboboxItem = all_students_groups.SelectedItem;
                    if (selectedComboboxItem != null)
                        studentsMain = await studentsJson.LoadList(StudentFilterLink + $"group/{selectedComboboxItem.ToString()}");
                }
                else
                {
                    studentsMain = await studentsJson.LoadList(studentsGetLink);
                }
            }
            else
            {
                studentsMain = await studentsJson.LoadList(studentsGetLink);
            }
            await LoadAllStudents(studentsMain);
        }

        private async void All_students_departments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            all_students_groups.Items.Clear();
            object selected = all_students_departments.SelectedItem;
            if (selected != null)
            {
                all_students_groups.Items.Clear();
                if (selected.ToString() != all_Departments_selected)
                {
                    all_students_groups.Items.Clear();
                    studentsMain = await studentsJson.LoadList(StudentFilterLink + $"department/{selected.ToString()}");
                    List<GroupUI> groupUIs = await new StudentController().GetGroupsByComboBoxDepartment(all_students_departments);
                    new StudentController().LoadAllGroupsToComboBox(all_students_groups, groupUIs);
                }
                else
                {
                    all_students_groups.Items.Clear();
                    studentsMain = await studentsJson.LoadList(studentsGetLink);
                    await new StudentController().LoadAllGroupsToComboBox(all_students_groups);
                }
                await LoadAllStudents(studentsMain);
            }
        }

        private async void Export_Click(object sender, RoutedEventArgs e)
        {
            UploadDataExcel uploadDataExcel = new UploadDataExcel();
            if (studentsMain != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранить студентов";
                saveFileDialog.Filter = "Excel|*.xlsx|Excel 97-2003|*.xls";
                saveFileDialog.FileName = "Students_" + DateTime.Now.ToString("dd_MM_yyyy");
                if (saveFileDialog.ShowDialog() == true)
                    await uploadDataExcel.UploadExcel(studentsMain, saveFileDialog.FileName);
            }
            else
            {
                SwitchError("Выберите студентов");
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private async void Students_list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)students_list.SelectedItem;
            List<object> values = row.Row.ItemArray.ToList();
            StudentUI studentUIEdit = (from st in studentsMain
                                       where st.Name == values[1].ToString() && st.Surname == values[2].ToString()
                                       select st).SingleOrDefault();
            editTab.Visibility = Visibility.Visible;
            tabs.SelectedItem = 2;
            LoadEditTab();
            UIElement insideEditGrid = editGrid.Children
              .Cast<UIElement>()
              .First(p => Grid.GetRow(p) == 0);
            foreach (UIElement p in (insideEditGrid as Grid).Children)
            {
                if (Grid.GetRow(p) == 0 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.Name;
                if (Grid.GetRow(p) == 1 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.Surname;
                if (Grid.GetRow(p) == 2 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.Fathername;
                if (Grid.GetRow(p) == 3 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.Email;
                if (Grid.GetRow(p) == 4 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.Phone;
                if (Grid.GetRow(p) == 5 && Grid.GetColumn(p) == 1)
                {
                    ComboBox numbers = ((p as Grid).Children
                          .Cast<UIElement>()
                          .First(k => Grid.GetColumn(k) == 0) as ComboBox);
                    ComboBox letters = ((p as Grid).Children
                          .Cast<UIElement>()
                          .First(k => Grid.GetColumn(k) == 1) as ComboBox);
                    for (int i = 1; i <= 11; i++)
                    {
                        numbers.Items.Add(i.ToString());
                    }
                    for (int i = 'А'; i <= 'Я'; i++)
                    {
                        letters.Items.Add(Convert.ToChar(i));
                    }
                }
                if (Grid.GetRow(p) == 6 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.SNILS;
                if (Grid.GetRow(p) == 7 && Grid.GetColumn(p) == 1) (p as TextBox).Text = studentUIEdit.MedPolis;
                if (Grid.GetRow(p) == 8 && Grid.GetColumn(p) == 1)
                {
                    List<RegionUI> _regions = await regionsJson.LoadList(regionLink);
                    if (_regions != null)
                    {
                        foreach (var item in _regions)
                        {
                            (p as ComboBox).Items.Add(item.NameRegion);
                        }
                    }
                    (p as ComboBox).SelectedItem = Task.Run(() => regionsJson.LoadModel(regionLink + "id/" +
         studentUIEdit.LocalCity.RegionId.ToString()).Result.NameRegion);
                    ;
                }
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            windowStyle = (windowStyle == WindowStyle.Dark ? WindowStyle.Light : WindowStyle.Dark);
            if (windowStyle == WindowStyle.Light)
            {
                CreateGrid.Style = (Style)FindResource("WhiteStyle");
                name.BorderBrush = Brushes.Red;
            }
            else if (windowStyle == WindowStyle.Dark)
            {
                CreateGrid.Style = (Style)FindResource("DarkStyle");
                name.BorderBrush = Brushes.White;
            }
        }

        private async void Settings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Window window = new Window();
            Settings window = new Settings();
            window.Width = 800;
            window.Height = 600;
            window.Title = "Settings";
            window.ShowDialog();
            //await new StudentController().LoadComboBox(window.Cities, await new
            //     StudentController().ObjectLoad<LocalCityUI>(localCitiesLink), "CityName");
        }
    }
}