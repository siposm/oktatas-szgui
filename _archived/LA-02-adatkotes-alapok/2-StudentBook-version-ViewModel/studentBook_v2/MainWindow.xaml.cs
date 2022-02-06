using System;
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

namespace studentBook_v2
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel svm { get; set; }
        private Student SelectedStudent { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            svm = new MainWindowViewModel();
            this.DataContext = svm;
        }


        // továbbhívjuk a ""logic"" metódusait mint prog3 esetén
        private void AddClick(object sender, RoutedEventArgs e)
        {
            svm.AddClick();
        }

        private void ModClick(object sender, RoutedEventArgs e)
        {
            svm.ModClick();
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            svm.DelClick();
        }

        private void PurClick(object sender, RoutedEventArgs e)
        {
            svm.PurClick();
        }
    }
}
