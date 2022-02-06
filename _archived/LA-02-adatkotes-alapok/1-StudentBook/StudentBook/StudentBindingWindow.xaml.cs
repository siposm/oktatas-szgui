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
    public partial class StudentBindingWindow : Window
    {
        // (A) verzió
        //public Student Student { get; set; }

        // (B) verzió
        // ebben az esetben kell a XAML-t is módosítani !!!
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
            this.DataContext = null; //ez azért kell mert a WPF nem reseteli a bindingokat ha oldDataContext.Equals(newDataContext)
            this.DataContext = s;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
