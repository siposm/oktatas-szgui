using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CommandExample
{
    public class MainWindowViewModel : ObservableRecipient
    {
        ICounterLogic logic;

        public int Counter
        {
            get
            {
                return logic.Counter;
            }
        }

        public ICommand IncreaseCommand { get; set; }


        public MainWindowViewModel()
            :this(IsInDesignMode ? null : Ioc.Default.GetService<ICounterLogic>())
        {

        }
        public MainWindowViewModel(ICounterLogic logic)
        {
            this.logic = logic;

            Messenger.Register<MainWindowViewModel, string, string>(this, "CounterResult", (recipient, msg) =>
            {
                   OnPropertyChanged("Counter");
                   (IncreaseCommand as RelayCommand).NotifyCanExecuteChanged();
            });
            IncreaseCommand = new RelayCommand(
                () => logic.Increase(),
                () => logic.Counter < 10
                );
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }



    }
}
