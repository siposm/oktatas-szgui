using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.BL;
using WpfApplication1.UI;
using WpfApplication1.VM;
/*
 * STEPS:
 * 1. PlayerClasses.cs
 * 2. IEditorService.cs, PlayerLogic.cs
 * 3. ViewModels.cs
 * 4. UI.*
 * 5. App.xaml.cs
 * 6. EditorWindow.xaml, MainWindow.xaml
 */
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // https://blog.ploeh.dk/2011/07/28/CompositionRoot/
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IEditorService, EditorServiceViaWindow>();
            SimpleIoc.Default.Register<IMessenger>(() => Messenger.Default);
            SimpleIoc.Default.Register<IPlayerLogic, PlayerLogic>();
        }
    }
}
