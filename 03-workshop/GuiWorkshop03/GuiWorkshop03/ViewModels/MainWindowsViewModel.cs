using GuiWorkshop03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuiWorkshop03.ViewModels
{
    public class MainWindowsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        public int Money
        {
            get
            {
                return this.Army.Sum(t => t.Cost * t.Power * t.Vitality);
            }
        }

        public BindingList<Trooper> Troopers { get; set; }

        public BindingList<Trooper> Army { get; set; }

        private Trooper selectedFromTrooper;

        public Trooper SelectedFromTrooper
        {
            get { return selectedFromTrooper; }
            set { selectedFromTrooper = value; }
        }

        private Trooper selectedFromArmy;

        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set { selectedFromArmy = value; }
        }


        public MainWindowsViewModel()
        {
            Troopers = new BindingList<Trooper>();
            Army = new BindingList<Trooper>();
            //mariner, pilot, infantry, sniper, engineer
            Troopers.Add(new Trooper()
            {
                Type = "marine",
                Power = 8,
                Vitality = 6,
                Cost = 6
            });
            Troopers.Add(new Trooper()
            {
                Type = "pilot",
                Power = 7,
                Vitality = 3,
                Cost = 10
            });
            Troopers.Add(new Trooper()
            {
                Type = "infantry",
                Power = 6,
                Vitality = 8,
                Cost = 10
            });
            Troopers.Add(new Trooper()
            {
                Type = "sniper",
                Power = 3,
                Vitality = 3,
                Cost = 7
            });
            Troopers.Add(new Trooper()
            {
                Type = "engineer",
                Power = 5,
                Vitality = 6,
                Cost = 8
            });

        }

        public void AddToArmy()
        {
            if (SelectedFromTrooper != null)
            {
                Army.Add(SelectedFromTrooper.GetCopy());
                OnPropertyChanged("Money");
            }
        }

        public void RemoveFromArmy()
        {
            if (SelectedFromArmy != null)
            {
                Army.Remove(SelectedFromArmy);
                OnPropertyChanged("Money");
            }
        }
    }
}
