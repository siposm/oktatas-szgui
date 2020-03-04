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
using WpfApp2.BL;
using WpfApp2.VM;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        string currentDirectory = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string currentDirectory)
            : this()
        {
            this.currentDirectory = currentDirectory;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MainWindowViewModel(currentDirectory);
            this.DataContext = viewModel;
        }

        // ??? Extra logic in xaml.cs ??? 
        // Commands are better!!!
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (viewModel.SelectedEntry == null) return;
            if (viewModel.SelectedEntry.IsDir)
            {
                MainWindow window = new MainWindow(viewModel.SelectedEntry.Name);
                window.Show();
            }
            else
            {
                System.Diagnostics.Process.Start(viewModel.SelectedEntry.Name);
            }
        }
    }
}
