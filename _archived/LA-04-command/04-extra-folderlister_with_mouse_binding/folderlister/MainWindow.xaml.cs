using folderlister.ViewModel;
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

namespace folderlister
{
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        string currentDirectory = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string currentDirectory) : this()
        {
            this.currentDirectory = currentDirectory;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MainWindowViewModel(currentDirectory);
            this.DataContext = viewModel;
        }
    }
}
