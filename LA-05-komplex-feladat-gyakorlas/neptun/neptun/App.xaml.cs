using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using neptun.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace neptun
{
    public partial class App : Application
    {
        //public App()
        //{
        //    ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        //    SimpleIoc.Default.Register<IMessenger>(() => Messenger.Default);
        //    SimpleIoc.Default.Register<IProfileLogic, ProfileLogic>();
        //}
    }
}
