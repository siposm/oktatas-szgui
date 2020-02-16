using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace basic_databinding
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person MyPerson { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            MyPerson = new Person() { FirstName = "Teszt", LastName = "Elek" };

            this.DataContext = MyPerson;            
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MyPerson.FirstName + " " + MyPerson.LastName);
            
            // breakpoint >> MyPerson megtekintése (keresés) >> látható, hogy felül lett írva a név = ADATKÖTÉS OK
        }
    }
}
