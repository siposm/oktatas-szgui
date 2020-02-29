using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_visual.Model
{
    class Player : ObservableObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public bool IsActive { get; set; }

        public int Hash
        {
            get { return Math.Abs(this.GetHashCode()); }
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode() * Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Player)
            {
                Player x = obj as Player;
                return x.ID == ID &&
                    x.Name == Name &&
                    x.BirthYear == BirthYear &&
                    x.IsActive == IsActive;
            }
            return false;
        }
    }
}
