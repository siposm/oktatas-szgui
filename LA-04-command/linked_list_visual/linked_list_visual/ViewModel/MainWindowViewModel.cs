using GalaSoft.MvvmLight;
using linked_list_visual.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_visual.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ChainedList<int> MyList { get; set; }

        public MainWindowViewModel()
        {
            MyList = new ChainedList<int>();
            MyList.Beszuras(10);
            MyList.Beszuras(46);
            MyList.Beszuras(213);
        }
    }
}
