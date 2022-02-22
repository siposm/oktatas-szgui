using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuiWorkshop03.Models
{
    public class Trooper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; OnPropertyChanged(); }
        }

        private int vitality;

        public int Vitality
        {
            get { return vitality; }
            set { vitality = value; OnPropertyChanged(); }
        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            set { cost = value; OnPropertyChanged(); }
        }

        public Trooper GetCopy()
        {
            return new Trooper()
            {
                Type = this.Type,
                Power = this.Power,
                Vitality = this.Vitality,
                Cost = this.Cost
            };
        }


    }
}
