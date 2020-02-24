using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using playercreator.Model;
using System.Xml.Linq;

namespace playercreator.ViewModel
{
    class MainWindowViewModel : ViewModelBase /* viewmodel includes inotify... */
    {
        public ObservableCollection<Player> PlayerList { get; set; }

        private int maxKillCountValue;
        public int MaxKillCountValue
        {
            get { return maxKillCountValue; }
            set { Set(ref maxKillCountValue, value); } // Raise property changed event
            
            // megoldás lenne még az is, ha az update... metódus tartalmát egyből a get részbe tennénk,
            // viszont akkor a GUI-n nem látszódna a kiszámolt érték... mert hiába van a label content bindingolva
            // a sima int változó nem tud szólni magáról, hogy az ő tartlma megváltozott... >> ezért kell INotify.
        }

        public void UpdateKillCountValue()
        {
            MaxKillCountValue = PlayerList.OrderByDescending(x => x.KillCount).First().KillCount;
        }

        public MainWindowViewModel()
        {
            PlayerList = new ObservableCollection<Player>();
            PlayerList.Add(new Player()
            {
                BirthYear = 1990,
                ID = "__ASD123",
                IsActive = true,
                Name = "TEST PLAYER"
            });

            PlayerList.Add(new Player()
            {
                BirthYear = 1988,
                ID = "__TEST12",
                IsActive = true,
                Name = "RANDOM PLAYER"
            });
        }
    }
}
