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
            
            departmentName2.IsEditable = true;
            departmentName2.Focusable = true;
            departmentName2.IsHitTestVisible = true;
            departmentName1.DropDownOpened -= this.DepartmentName1_DropDownOpened;
        }
        private async void DepartmentName2_DropDownOpened(object sender, EventArgs e)
        {
            await LoadDepartments(departmentName2);
            departmentName3.IsEditable = true;
            departmentName3.Focusable = true;
            departmentName3.IsHitTestVisible = true;
            departmentName2.DropDownOpened -= this.DepartmentName1_DropDownOpened;
        }
        private async void DepartmentName3_DropDownOpened(object sender, EventArgs e)
        {
            await LoadDepartments(departmentName3);
            departmentName3.DropDownOpened -= this.DepartmentName3_DropDownOpened;
        }

        private async void Regions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cities.Items.Clear();
            string Value = "";
            if (regions.SelectedIndex >= 0)
                Value = regions.SelectedItem.ToString();
            List<LocalCityUI> localcities = await LoadDataFromJson<LocalCityUI>.LoadList("https://localhost:44357/api/citylocal/"+Value);
            if (localcities != null)
            {
                foreach (var item in localcities)
                {
                    cities.Items.Add(item.CityName);
                }
            }
        }
    }
}
