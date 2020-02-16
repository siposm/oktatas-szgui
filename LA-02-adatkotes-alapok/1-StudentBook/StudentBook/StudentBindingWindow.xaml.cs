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
using System.Windows.Shapes;

namespace StudentBook
{
    /// <summary>
    /// Interaction logic for StudentBindingWindow.xaml
    /// </summary>
    public partial class StudentBindingWindow : Window
    {
        // (A) verzió
        //public Student Student { get; set; }

        // (B) verzió
        public Student Student
        {
            get { return this.DataContext as Student; }
        }

        public StudentBindingWindow()
        {
            InitializeComponent();
        }

        // modify student
        public StudentBindingWindow(Student s) : this()
        {
            this.DataContext = s;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
