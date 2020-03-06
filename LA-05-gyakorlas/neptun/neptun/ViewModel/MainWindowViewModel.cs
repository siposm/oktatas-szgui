using neptun.BusinessLogic;
using neptun.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace neptun.ViewModel
{
    class MainWindowViewModel
    {
        public ObservableCollection<Profile> ProfileCollection { get; set; }
        public Profile SelectedProfile { get; set; }
        public ICommand AddNewCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public MainWindowViewModel()
        {
            ProfileCollection = new ObservableCollection<Profile>();

            DataLoadingService dls = new DataLoadingService();
            dls.FetchData().ForEach(x => ProfileCollection.Add(x));
        }
    }
}
