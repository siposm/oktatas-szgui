using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StudentListBox.Items.Add(new Student()
            {
                Name = "Kiss Lajos",
                NeptunCode = "ROF982",
                EnrollmentDate = new DateTime(2015, 09, 10),
                IsActive = false
            });

            StudentListBox.Items.Add(new Student()
            {
                Name = "Tóth Imre",
                NeptunCode = "BA7AF3",
                EnrollmentDate = new DateTime(2012, 09, 10),
                IsActive = true
            });

            StudentListBox.Items.Add(new Student()
            {
                Name = "Varga Andrea",
                NeptunCode = "H3LL0C",
                EnrollmentDate = new DateTime(2014, 09, 10),
                IsActive = true
            });
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            StudentBindingWindow sbw = new StudentBindingWindow();
            if (sbw.ShowDialog() == true)
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
