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

        // PUBLIC SETTER IN VM = DANGER
        // NOT DISPLAYED IN WINDOW = NO PROBLEM
        public DirectoryEntry SelectedEntry { get; set; }

        public MainWindowViewModel(
            IDirectoryLogic directoryLogic,
            string currentDirectory)
        {
            this.directoryLogic = directoryLogic;
            CurrentDirectory = currentDirectory;

            Entries = directoryLogic.CollectDirectoryEntries(currentDirectory);

            SelectEntryCommand = new RelayCommand( () => {
                    this.directoryLogic.SelectEntry(SelectedEntry); // MUST reference the datafield!
                });
        }

        public MainWindowViewModel(string currentDirectory)
            : this(new DirectoryLogic(), currentDirectory)
        {
        }
    }
}
