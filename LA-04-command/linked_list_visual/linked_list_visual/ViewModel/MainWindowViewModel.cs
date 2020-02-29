using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf; // !!!!!!!
using linked_list_visual.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace linked_list_visual.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ChainedList<Player> MyList { get; set; }
        public ICommand AddNewCommand { get; private set; }
        public ICommand RemoveSelectedCommand { get; private set; }
        public Player SelectedPlayer { get; set; }

        public MainWindowViewModel()
        {
            AddNewCommand = new RelayCommand(() => this.Add());
            RemoveSelectedCommand = new RelayCommand(() => this.Remove());
            MyList = new ChainedList<Player>();
            LoadPlayers();
        }

        private void Remove()
        {
            MyList.Remove(SelectedPlayer);
        }

        private void Add()
        {
            NewPlayerWindow npw = new NewPlayerWindow();
            Player newPlayer = new Player();
            npw.DataContext = newPlayer;
            if(npw.ShowDialog() == true)
                MyList.Insert(newPlayer, false);

            // alapból a lista végére rakunk (false)
            // itt most jól is jön ki mert a GUI-nál trükközni kéne, hogy a lista elejére való beszúráskor ott is jelenjen meg
        }

        private void LoadPlayers()
        {
            WebClient wc = new WebClient();
            string playersString = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/db/players.json");
            var q = JsonConvert.DeserializeObject<List<Player>>(playersString);
            foreach (var item in q)
                MyList.Insert(item as Player, false);
        }
    }
}
