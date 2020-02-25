using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playercreator.Model
{
    public class Player : ObservableObject 
    {
        private string name;
        public string Name
        {
            get { return name; }
            //set { name = value; }
            set { Set(ref name, value); RaisePropertyChanged(nameof(Name)); }
        }


        public string ID { get; set; }
        //public string Name { get; set; }
        public int BirthYear { get; set; }
        public bool IsActive { get; set; }
        public int KillCount
        {
            get
            {
                int sum = 1;
                for (int i = 0; i < 4; i++)
                {
                    if( int.Parse(BirthYear.ToString()[i].ToString()) != 0 )
                        sum *= int.Parse(BirthYear.ToString()[i].ToString()); // :)
                }
                return sum;
            }
            // set >> nincs set >> OneWay binding
        }
    }
}
