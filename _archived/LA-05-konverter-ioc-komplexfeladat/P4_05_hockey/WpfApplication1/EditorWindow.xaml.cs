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
using WpfApplication1.Data;
using WpfApplication1.VM;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for OtherWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        EditorViewModel VM;
        public Player Player { get { return VM.Player; } }
        public EditorWindow() 
        {
            InitializeComponent();
            VM = FindResource("VM") as EditorViewModel;
        }
        public EditorWindow(Player newplayer) : this()
        {
            VM.Player = newplayer;
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
