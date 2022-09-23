using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientApp.VM
{
    public class NameWindowViewModel
    {

        private string enteredName;

        public string EnteredName
        {
            get { return enteredName; }
            set { enteredName = value; (OkCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }


        public ICommand OkCommand { get; set; }

        public NameWindowViewModel(Window window)
        {
            OkCommand = new RelayCommand(() => { window.DialogResult = true; }, () => { return EnteredName != null && EnteredName != ""; });
        }

    }
}
