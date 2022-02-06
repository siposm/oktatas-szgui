using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace design_time_datacontext.Model
{
    class Pizza : INotifyPropertyChanged // később observable object (mvvm light libs)
    {
        //public int ID { get; set; }
        //public string Name { get; set; }
        //public int Diameter { get; set; }
        // OPC esetén teljes adattag+prop kell, a set ág miatt...

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
            // kieg 1.: callermembername ha nincs: OnPropertyChanged (ID)
            // kieg 2.: observable object esetén példa:  set { Set(ref size, value); RaisePropertyChanged(nameof(TotalPrice)); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private int diameter;
        public int Diameter
        {
            get { return diameter; }
            set { diameter = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
