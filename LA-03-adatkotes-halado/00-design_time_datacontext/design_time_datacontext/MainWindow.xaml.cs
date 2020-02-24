using design_time_datacontext.Model;
using design_time_datacontext.ViewModel;
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

namespace design_time_datacontext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PizzaViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = FindResource("my_viewmodel") as PizzaViewModel;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            vm.PizzaCollection.Add(new Pizza()
            {
                ID = 999, Name = "TEST PIZZA", Diameter = 500
            });
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            vm.PizzaCollection.RemoveAt(0);
            // LIST ESETÉN:
            // ha nyomkodjuk a remove gombot, akkor egy idő után elfogynak az elemek,
            // ekkor exceptiont kapunk (holott a GUI szerint még mindig van benne elem...)
        }

        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            vm.PizzaCollection.First().Name = "This is the new name";
            // sima class esetén:
            // nem fogjuk látni a GUI-n az updatelt nevet, de breakpointtal megállva itt látható hogy módosításra került...
        }
    }
}
