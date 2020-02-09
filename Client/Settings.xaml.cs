using Client.Controllers;
using Client.LoadData;
using Client.ModelsUI;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        LoadDataFromJson<RegionUI> regionsJson;
        List<SchoolUI> schoolUIs;
        int count;
        string regionLink = ConfigurationSettings.AppSettings["RegionGetLink"].ToString();
        DataTable dataTable;
        List<RegionUI> citiList;
        SchoolController schoolController;
        public Settings()
        {
            InitializeComponent();
            regionsJson = new LoadDataFromJson<RegionUI>();
            count = 0;
            dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("City");
            schoolUIs = new List<SchoolUI>();
            schoolController = new SchoolController();
            LoadSchools();
        }
        private async void LoadSchools()
        {
            citiList = await new StudentController().ObjectLoad<RegionUI>(regionLink);
            if (citiList != null) await new StudentController().LoadComboBox(Cities, citiList, "NameRegion");
            List<SchoolUI> schools = await new SchoolController().Get();
            foreach(SchoolUI school in schools)
            {
                count++;
                string[] row = new string[3];
                row[0] = school.Id.ToString();
                row[1] = school.Title.ToString();
                row[2] = school.RegionId.ToString();
                dataTable.Rows.Add(row);
            }
            SchoolGrid.ItemsSource = dataTable.DefaultView;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Add_MouseUp(object sender, RoutedEventArgs e)
        {
            if (TitleSchool.Text != "" && Cities.SelectedIndex != -1)
            {
                count++;
                string[] row = new string[3];
                row[0] = count.ToString();
                row[1] = TitleSchool.Text.ToString();
                row[2] = Cities.SelectedValue.ToString();
                int id = citiList.FirstOrDefault(x => x.NameRegion == row[2]).Id;
                schoolUIs.Add(new SchoolUI() { Title = row[0], RegionId = id });
                dataTable.Rows.Add(row);
                SchoolGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private async void Save_MouseUp(object sender, RoutedEventArgs e)
        {
            foreach (var school in schoolUIs)
            {
                await schoolController.Add(school);
            }
            schoolUIs.Clear();
        }
    }
}