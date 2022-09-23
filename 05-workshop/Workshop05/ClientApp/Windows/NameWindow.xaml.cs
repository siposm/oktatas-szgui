using ClientApp.VM;
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

namespace ClientApp.Windows
{
    /// <summary>
    /// Interaction logic for NameWindow.xaml
    /// </summary>
    public partial class NameWindow : Window
    {
        public NameWindowViewModel VM { get; set; }

        public NameWindow()
        {
            InitializeComponent();
            VM = new NameWindowViewModel(this);
            this.DataContext = VM;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (VM.EnteredName == null || VM.EnteredName == "")
            {
                e.Cancel = true;
            }
        }
    }
}
