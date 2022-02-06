using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.BL;

namespace WpfApp2.VM
{
    class MainWindowViewModel : ViewModelBase
    {
        private IDirectoryLogic directoryLogic;

        public IEnumerable<DirectoryEntry> Entries { get; private set; }
        public string CurrentDirectory { get; private set; }
        public ICommand SelectEntryCommand { get; private set; }

        private DirectoryEntry selectedEntry;
        public DirectoryEntry SelectedEntry
        {
            get { return selectedEntry; }
            set { Set(ref selectedEntry, value); }
        }


        public MainWindowViewModel(
            IDirectoryLogic directoryLogic,
            string currentDirectory)
        {
            this.directoryLogic = directoryLogic;
            CurrentDirectory = currentDirectory;

            Entries = directoryLogic.CollectDirectoryEntries(currentDirectory);

            SelectEntryCommand = new RelayCommand(
                () => {
                    this.directoryLogic.SelectEntry(SelectedEntry); // MUST reference the datafield!
                });

            // ONLY if there is time:
            // IF free variable = closure = can use hard reference since 5.4.0
            // PROBLEM: possible memory leak, this will be detailed in the lecture
            // http://galasoft.ch/s/mvvmweakaction
            /*
            SelectEntryCommand = new RelayCommand(
                () => {
                    directoryLogic.SelectEntry(SelectedEntry);  // uses the parameter, not the datafield!
                }, true);
             */
        }

        public MainWindowViewModel(string currentDirectory)
            :this(new DirectoryLogic(new EntrySelectorViaWindow()), currentDirectory) 
        {
        }
        // TODO: extract this ctor into an IoC, to avoid chain-of-depepndency!!!
    }
}
