using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;
using Newtonsoft.Json;
using playercreator.Model;
using playercreator.ViewModel;

namespace playercreator
{
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            vm = FindResource("my_viewmodel") as MainWindowViewModel;
            //this.DataContext = vm; // nem kell!
        }





        // button click egyelőre itt foglal helyett >> jobb megoldás commandok használata (MVVM) = jobb leválasztás!
        private void ExportClick(object sender, RoutedEventArgs e)
        {
            string toSave = JsonConvert.SerializeObject(vm.PlayerList, Formatting.Indented);
            string fileName = "SAVED_players.json";
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(toSave);
            sw.Close();

            new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Arguments = fileName,
                    FileName = "notepad++.exe"
                }
            }.Start();
        }

        private void LoadXMLClick(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load("http://users.nik.uni-obuda.hu/siposm/db/players.xml");
            foreach (var item in xdoc.Root.Descendants("player"))
            {
                vm.PlayerList.Add(new Player()
                {
                    ID = item.Element("ID").Value,
                    Name = item.Element("name").Value,
                    BirthYear = int.Parse(item.Element("birthYear").Value),
                    IsActive = bool.Parse(item.Element("isActive").Value)
                });
            }

            vm.UpdateKillCountValue();
        }

        private void LoadJSONClick(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            string playersString = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/db/players.json");
            var q = JsonConvert.DeserializeObject<List<Player>>(playersString);
            foreach (var item in q)
                vm.PlayerList.Add(item);

            vm.UpdateKillCountValue();
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            // with single select option:
            //vm.PlayerList.RemoveAt(ListboxPlayers.SelectedIndex); 

            // with multi select option:
            List<Player> toDelete = new List<Player>();
            foreach (var item in ListboxPlayers.SelectedItems)
                toDelete.Add(item as Player);

            foreach (var item in toDelete)
                vm.PlayerList.Remove(item as Player);

            vm.UpdateKillCountValue();
        }

        private void OrderDescClick(object sender, RoutedEventArgs e)
        {
            List<Player> tempList = new List<Player>();
            tempList.AddRange(vm.PlayerList.OrderByDescending(y => y.Name));
            vm.PlayerList.Clear();
            tempList.ForEach(x => vm.PlayerList.Add(x));
        }

        private void OrderAscClick(object sender, RoutedEventArgs e)
        {
            List<Player> tempList = new List<Player>();
            tempList.AddRange(vm.PlayerList.OrderBy(y => y.Name));
            vm.PlayerList.Clear();
            tempList.ForEach(x => vm.PlayerList.Add(x));
        }

        private void TopKillsClick(object sender, RoutedEventArgs e)
        {
            var q = vm.PlayerList.OrderByDescending(x => x.KillCount).Take(10);
            string s = "";
            foreach (var item in q)
                s += string.Format($"{item.Name} : {item.KillCount}\n");

            MessageBox.Show(s);
        }

        private void PurgeClick(object sender, RoutedEventArgs e)
        {
            vm.PlayerList.Clear();
        }

        private void RandomizeClick(object sender, RoutedEventArgs e)
        {
            vm.PlayerList.First().Name = "THIS IS THE NEW NAME";
        }
    }
}
