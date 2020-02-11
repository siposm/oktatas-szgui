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

namespace routedDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] LookUpTable;

        public MainWindow()
        {
            InitializeComponent();

            LookUpTable = new string[]
            {
                // movie name ; year of release ; length (mins)
                "Parasite;2007;186",
                "Castle Rock;1990;109",
                "Megszállottak viadala;1993;133",
                "Into the Dark;1993;174",
                "Tolvajok az erdőből;2001;119",
                "Terror;2001;72",
                "The Purge;2005;107",
                "Black Lightning;1983;142",
                "Cobra Kai;1993;183",
                "Elit;1999;188",
                "Aljas John;1982;73",
                "Legacies: A sötétség öröksége;2014;150",
                "Valós halál;2008;105",
                "Sabrina hátborzongató kalandjai;2005;191",
                "Lost in Space - Elveszve az űrben;2020;135",
                "Diablero;1994;92"
            };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var name = (e.Source as Label).Content.ToString();

            foreach (string item in LookUpTable)
            {
                if (item.Split(';')[0].Equals(name))
                    MessageBox.Show(
                        "NAME: " + name +
                        "\nYEAR: " + item.Split(';')[1] +
                        "\nLENGTH: " + item.Split(';')[2]
                        );
            }
        }
    }
}
