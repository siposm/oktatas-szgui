using folderlister.BusinessLogic;
using folderlister.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace folderlister.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private IDirectoryLogic directoryLogic;

        public IEnumerable<DirectoryEntry> Entries { get; private set; }
        public string CurrentDirectory { get; private set; }
        public ICommand SelectEntryCommand { get; private set; }
        public ICommand LogCurrentCommand { get; private set; }
        public ICommand TestDCCommand { get; private set; }
        public DirectoryEntry SelectedEntry { get; set; }

        public MainWindowViewModel(IDirectoryLogic directoryLogic, string currentDirectory)
        {
            this.directoryLogic = directoryLogic;
            CurrentDirectory = currentDirectory;

            Entries = directoryLogic.CollectDirectoryEntries(currentDirectory);

            TestDCCommand = new RelayCommand(() =>
            {
                this.directoryLogic.SelectEntry(SelectedEntry);
            });

            SelectEntryCommand = new RelayCommand(() => 
            {
               this.directoryLogic.SelectEntry(SelectedEntry);
            });

            LogCurrentCommand = new RelayCommand(() =>
            {
                this.directoryLogic.LogCurrent(CurrentDirectory);
            });
        }

        public MainWindowViewModel(string currentDirectory) : this(new DirectoryLogic(), currentDirectory)
        {
        }
    }
}
