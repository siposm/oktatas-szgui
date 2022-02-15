using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> notes;
        public MainWindow()
        {
            InitializeComponent();
            notes = new Dictionary<string, string>();
        }

        private void CreateNote(object sender, RoutedEventArgs e)
        {
            notes.Add(tb_newnote.Text,"");
            RefreshNoteList();
        }

        private void Import(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.json"))
            {
                notes = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("data.json"));
                foreach (var item in notes.Keys)
                {
                    lbox.Items.Add(item);
                }
            }
            
        }

        private void Export(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllText("data.json", JsonConvert.SerializeObject(notes));
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                tb_editor.Text = notes[(string)lbox.SelectedItem];
            }
        }

        private void Changed(object sender, TextChangedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                notes[(string)lbox.SelectedItem] = tb_editor.Text;
            }
        }

        private void Delete(object sender, MouseButtonEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                notes.Remove((string)lbox.SelectedItem);
            }
            RefreshNoteList();
        }

        private void RefreshNoteList()
        {
            lbox.Items.Clear();
            foreach (var item in notes.Keys)
            {
                lbox.Items.Add(item);
            }
            lbox.SelectedItem = tb_newnote.Text;
        }
    }
}
