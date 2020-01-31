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
    public class Person //: INotifyPropertyChanged
    {

        public string Name { get; set; }
        public string Age { get; set; }

        #region interface-megvalositas
        //public event PropertyChangedEventHandler PropertyChanged;

        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
        //    }
        //}

        //private string age;
        //public string Age
        //{
        //    get { return age; }
        //    set
        //    {
        //        age = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
        //    }
        //}
        #endregion

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

            MyPerson = new Person();
            MyPerson.Name = "Hi, I'm the Test Person.";
            MyPerson.Age = "... and I'm 20 yo.";

            this.DataContext = MyPerson;
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            ;
            // breakpoint >> MyPerson megtekintése >> látható, hogy felül lett írva a név (de ez mégsem jelenik meg a GUI-n...) >> inotify...
        }
    }
}
