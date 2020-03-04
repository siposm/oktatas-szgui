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
        public ChainedList<Profile> ProfileCollection { get; set; }
        public Profile SelectedProfile { get; set; }
        public ICommand AddNewCommand { get; private set; }
        public ICommand RemoveSelectedCommand { get; private set; }
        
        public MainWindowViewModel()
        {
            AddNewCommand = new RelayCommand(() => this.Add());
            RemoveSelectedCommand = new RelayCommand(() => this.Remove());
            ProfileCollection = new ChainedList<Profile>();
            LoadPlayers();
        }




        private void Remove()
        {
            ProfileCollection.Remove(SelectedProfile);
        }

        private void Add()
        {
            NewPlayerWindow npw = new NewPlayerWindow();
            Profile newProfile = new Profile();
            npw.DataContext = newProfile;
            if(npw.ShowDialog() == true)
            {
                newProfile.Image = "https://randomuser.me/api/portraits/men/";
                newProfile.Image += new Random().Next(0, 60).ToString() + ".jpg";
                ProfileCollection.Insert(newProfile, false);
            }

            // alapból a lista végére rakunk (false)
            // itt most jól is jön ki mert a GUI-nál trükközni kéne, hogy a lista elejére való beszúráskor ott is jelenjen meg
            // eddig ez nem jött elő, mert list és obscoll esetén is a végére rak a .Add
        }

        private void LoadPlayers()
        {
            WebClient wc = new WebClient();
            string playersString = wc.DownloadString("http://users.nik.uni-obuda.hu/siposm/db/players_v2.json");
            JsonConvert
                .DeserializeObject<List<Profile>>(playersString)
                .ForEach(x => ProfileCollection.Insert(x, false));
        }
    }
}
