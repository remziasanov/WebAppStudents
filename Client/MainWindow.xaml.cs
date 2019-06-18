using Client.ModelsUI;
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
            GetALLTEst();
        }
        private readonly HttpClient _client;
        public async Task GetALLTEst()
        {
            List<StudentUI> students=null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44357/api/values");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<StudentUI>>(data);

                }
            }
            //if(students!=null)
            //Parent1.Text = students.First().Id.ToString();


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

        private async void DepartmentName1_DropDownOpened(object sender, EventArgs e)
        {
            List<DepartmentUI> departments = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44357/api/department");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    departments = JsonConvert.DeserializeObject<List<DepartmentUI>>(data);

                }
            }
            if(departments!=null)
            {
                foreach (var item in departments)
                {
                    departmentName1.Items.Add(item.Title);

                }
            }
            departmentName1.DropDownOpened -= this.DepartmentName1_DropDownOpened;
        }
    }
}
