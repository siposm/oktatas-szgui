using GalaSoft.MvvmLight.CommandWpf;
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
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public MainWindowViewModel()
        {
            ProfileCollection = new ObservableCollection<Profile>();

            DataLoadingService dls = new DataLoadingService();
            dls.FetchData().ForEach(x => ProfileCollection.Add(x));

            AddCommand = new RelayCommand(() => this.AddNew());
            RemoveCommand = new RelayCommand(() => this.Remove());
        }

        private void AddNew()
        {
            DataLoadingService dls = new DataLoadingService();

            ProfileCollection.Add(new Profile()
            {
                ID = dls.GenerateID()
            });
        }

        private void Remove()
        {
            ProfileCollection.Remove(SelectedProfile);
        }
    }
}
