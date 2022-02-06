using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.BL;
using WpfApplication1.Data;

namespace WpfApplication1.VM
{
    class EditorViewModel : ViewModelBase
    {
        Player player;
        public Player Player
        {
            get { return player; }
            set { Set(ref player, value); }
        }

        public Array Positions
        {
            get { return Enum.GetValues(typeof(PositionType)); }
        }
        public Array Statuses
        {
            get { return Enum.GetValues(typeof(StatusType)); }
        }
        public EditorViewModel()
        {
            player = new Player();
            player.Name = "Unknown Béla XXX";
        }
    }

    class MainViewModel : ViewModelBase
    {
        IPlayerLogic logic;

        Player teamSelected;
        public Player TeamSelected
        {
            get { return teamSelected; }
            set { Set(ref teamSelected, value); }
        }

        public ObservableCollection<Player> Team { get; private set; }

        public ICommand AddCmd { get; private set; }
        public ICommand ModCmd { get; private set; }
        public ICommand DelCmd { get; private set; }

        public MainViewModel(IPlayerLogic logic)
        {
            this.logic = logic;

            Team = new ObservableCollection<Player>();

            if (IsInDesignMode)
            {
                Player p2 = new Player() { Name = "Wild Bill 2" };
                Player p3 = new Player() { Name = "Wild Bill 3", Status = StatusType.Injured };
                Team.Add(p2);
                Team.Add(p3);
            }

            // MUST USE commandWpf!
            // MUST USE this.logic
            AddCmd = new RelayCommand(() => this.logic.AddPlayer(Team)); 
            ModCmd = new RelayCommand(() => this.logic.ModPlayer(TeamSelected)); 
            DelCmd = new RelayCommand(() => this.logic.DelPlayer(Team, TeamSelected));
        }

        // Only to have a zero-parameter constructor!!!
        //public MainViewModel()
        //    : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IPlayerLogic>())
        //{
        //}

        /*
        BOTH WOULD BE VERY BAD ("BAD USAGE OF IOC" in the lectures, a.k.a. HIDDEN DEPENDENCY!!!)

        IPlayerLogic Logic
        {
            get { return ServiceLocator.Current.GetInstance<IPlayerLogic>(); }
        }
        MainViewModel(){
            logic = ServiceLocator.Current.GetInstance<IPlayerLogic>();
        }
        
         *** MUST use ***
         1. IPlayerLogic ctor parameter in ViewModel AND
         2. use a Factory/IoC to create the viewModel instance AND
         3. use the Factory/IoC in the xaml
        */
    }
}
