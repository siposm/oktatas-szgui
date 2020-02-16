using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace StudentBook
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //LoadStudentsManually();
            LoadStudentsFromJson();
        }

        private void LoadStudentsManually()
        {
            StudentListBox.Items.Add(new Student()
            {
                Name = "Kiss Lajos",
                NeptunCode = "ROF982",
                EnrollmentYear = 2015,
                IsActive = false
            });

            StudentListBox.Items.Add(new Student()
            {
                Name = "Tóth Imre",
                NeptunCode = "BA7AF3",
                EnrollmentYear = 2012,
                IsActive = true
            });

            StudentListBox.Items.Add(new Student()
            {
                Name = "Varga Andrea",
                NeptunCode = "H3LL0C",
                EnrollmentYear = 2014,
                IsActive = true
            });
        }

        private void LoadStudentsFromJson()
        {
            // json class >> nuget >> newtonsoft.json

            string url = "http://users.nik.uni-obuda.hu/siposm/db/students.json";

            WebClient wc = new WebClient();
            string jsonContent = wc.DownloadString(url);
            JsonConvert.DeserializeObject<List<Student>>(jsonContent).ForEach( x =>
            {
                StudentListBox.Items.Add(x);
            });
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            StudentBindingWindow sbw = new StudentBindingWindow();

            if (sbw.ShowDialog() == true) // modális megjelenítés
                StudentListBox.Items.Add(sbw.Student);
        }

        private void ModClick(object sender, RoutedEventArgs e)
        {
            if (StudentListBox.SelectedItem == null) return;
            Student stud = StudentListBox.SelectedItem as Student;
            StudentBindingWindow window = new StudentBindingWindow(stud);
            if (window.ShowDialog() == true)
            {
                MessageBox.Show("OK, modified");
            }
            else
            {
                // todo: edit a copy => Prototype design pattern!
                MessageBox.Show("BUG: cannot cancel a BINDING!!!");
            }
            StudentListBox.Items.Refresh(); // később observable collection...
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (StudentListBox.SelectedItem == null) return;

            StudentListBox.Items.Remove(StudentListBox.SelectedItem);
        }

        private void PurClick(object sender, RoutedEventArgs e)
        {
            StudentListBox.Items.Clear();
        }
    }
}
