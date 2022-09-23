using ClientApp.VM;
using Microsoft.Toolkit.Mvvm.Messaging;
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
using Workshop05.ClientApp;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // Mediator pattern, better than hacky VM access from window
            WeakReferenceMessenger.Default.Register<object, string, string>(this, "ChatChanged", (sender, args) =>
            {
                scrollviewer.ScrollToBottom();
            });
        }

        // Event redirect
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Mediator pattern, forward event to VM
            WeakReferenceMessenger.Default.Send("MainWindowLoaded", "MainWindowLoaded");
        }
    }
}
