using GuiWorkshop03.ViewModels;
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

namespace GuiWorkshop03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowsViewModel).AddToArmy();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowsViewModel).RemoveFromArmy();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TrooperEditor te = new TrooperEditor((this.DataContext as MainWindowsViewModel).SelectedFromTrooper);
            te.ShowDialog();
        }
    }
}
