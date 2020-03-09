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
        private IProfileLogic logic;
        public ObservableCollection<Profile> ProfileCollection { get; private set; }
        private Profile selectedProfile;
        public Profile SelectedProfile
        {
            get { return selectedProfile; }
            set { Set(ref selectedProfile, value); } // viewmodelbase öröklődés miatt kell a Set() használat, különben nem működik a binding a sima get;set; verzióval
        }
        //public Profile SelectedProfile { get; set; } 

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public MainWindowViewModel(IProfileLogic logic)
        {
            this.logic = logic;

            ProfileCollection = new ObservableCollection<Profile>();

            DataLoadingService dls = new DataLoadingService();
            dls.FetchData().ForEach(x => this.logic.AddExistingProfile(ProfileCollection, x));

            AddCommand = new RelayCommand(() => this.AddNew());
            RemoveCommand = new RelayCommand(() => this.Remove());
        }

        // csak azért, hogy legyen nulla paraméteres ctor
        public MainWindowViewModel() : this(ServiceLocator.Current.GetInstance<IProfileLogic>())
        {
        }

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
