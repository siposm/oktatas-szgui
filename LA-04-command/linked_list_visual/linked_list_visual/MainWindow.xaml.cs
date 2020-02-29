using linked_list_visual.ViewModel;
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

namespace linked_list_visual
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            vm = FindResource("my_viewmodel") as MainWindowViewModel;
        }
    }
}
