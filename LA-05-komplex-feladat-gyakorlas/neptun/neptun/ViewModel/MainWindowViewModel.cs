using CommonServiceLocator;
using GalaSoft.MvvmLight;
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
    class MainWindowViewModel : ViewModelBase
    {
        IProfileLogic logic;
        public ObservableCollection<Profile> ProfileCollection { get; set; }
        public Profile SelectedProfile { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public MainWindowViewModel(IProfileLogic logic)
        {
            this.logic = logic;

            ProfileCollection = new ObservableCollection<Profile>();

            DataLoadingService dls = new DataLoadingService();
            dls.FetchData().ForEach(x => this.logic.AddProfile(ProfileCollection, x));

            AddCommand = new RelayCommand(() => this.AddNew());
            RemoveCommand = new RelayCommand(() => this.Remove());
        }

        //public MainWindowViewModel()
        //   : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IProfileLogic>())
        //{
        //}

        private void AddNew()
        {
            this.logic.AddNewProfile(ProfileCollection);
        }

        private void Remove()
        {
            this.logic.RemoveProfile(ProfileCollection, SelectedProfile);
        }
    }
}
