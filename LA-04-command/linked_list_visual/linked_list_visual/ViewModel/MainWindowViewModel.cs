using GalaSoft.MvvmLight;
using linked_list_visual.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_visual.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ChainedList<Player> MyList { get; set; }
        
        public MainWindowViewModel()
        {
            MyList = new ChainedList<Player>();
            MyList.Beszuras(new Player() { Name = "Lorem Ipsum" });
            MyList.Beszuras(new Player() { Name = "Dolor sit amet" });
            MyList.Beszuras(new Player() { Name = "Dum spiro spero" });

            MyList.Beszuras(new Player() { Name = "Lorem Ipsum" });
            MyList.Beszuras(new Player() { Name = "Dolor sit amet" });
            MyList.Beszuras(new Player() { Name = "Dum spiro spero" });
        }
    }
}
