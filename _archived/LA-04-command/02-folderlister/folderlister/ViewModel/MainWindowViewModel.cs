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

        // PUBLIC SETTER IN VM = DANGER
        // NOT DISPLAYED IN WINDOW = NO PROBLEM
        public DirectoryEntry SelectedEntry { get; set; }

        public MainWindowViewModel(IDirectoryLogic directoryLogic, string currentDirectory)
        {
            this.directoryLogic = directoryLogic;
            CurrentDirectory = currentDirectory;

            Entries = directoryLogic.CollectDirectoryEntries(currentDirectory);

            SelectEntryCommand = new RelayCommand(() => 
            {
               this.directoryLogic.SelectEntry(SelectedEntry); // MUSZÁJ az adattagra hivatkozni (azaz this . dirlogic)!
            });

            LogCurrentCommand = new RelayCommand(() =>
            {
                this.directoryLogic.LogCurrent(CurrentDirectory); // currentDirectory a belső változót jelenti, úgy nem lesz jó!
            });
        }

        public MainWindowViewModel(string currentDirectory) : this(new DirectoryLogic(), currentDirectory)
        {
        }
    }
}
