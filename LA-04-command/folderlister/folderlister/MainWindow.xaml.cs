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

        public MainWindow(string currentDirectory)// : this()
        {
            this.currentDirectory = currentDirectory;
            InitializeComponent(); // this esetén ez a sor elhagyható
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  d: DataContext (XAML) >> csak design időben hozza létre a példányt (autocomplete)
            //  DE futási időben nem, ezért kell itt létrehozni a példányt:
            viewModel = new MainWindowViewModel(currentDirectory);
            this.DataContext = viewModel;
        }



        // A minimálisan szükséges "logikán" kívül _nem_ teszünk mást a xaml.cs-be! 
        // Helyette command-okat használunk!
        // Lásd "open" button binding rész XAML-ben.
        //
        // A félévben jó és elég ha a button click-ekre vannak commandok létrehozva, másra nem kell.
        // Akit érdekel viszont, hogy hogyan kell: https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/may/mvvm-commands-relaycommands-and-eventtocommand
        // Kulcsszavak: AttachedProperty, EventToCommand trigger

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (viewModel.SelectedEntry == null) return;
            if (viewModel.SelectedEntry.IsDir)
            {
                MainWindow window = new MainWindow(viewModel.SelectedEntry.Name);
                window.Show(); // itt alapvetően nem érdekel, hogy mi lesz az ablakkal, ezért nem showdialog-ot használunk
            }
            else
            {
                System.Diagnostics.Process.Start(viewModel.SelectedEntry.Name);
            }
        }

        private void Test(/* ... */)
        {
            // viewModel.SelectEntryCommand.Execute(null);
            // ha kellene és le akarnánk, akkor a VM-ben lévő command továbbhívató innen
            // így pl. egy mouse down event kivlátható szépen, anélkül hogy adatkötnénk
        }
    }
}
