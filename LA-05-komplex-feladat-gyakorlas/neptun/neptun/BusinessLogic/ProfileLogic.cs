using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging; // !!!
using neptun.Model;

namespace neptun.BusinessLogic
{
    class ProfileLogic : IProfileLogic
    {
        IMessenger messengerService;

        public ProfileLogic(IMessenger service)
        {
            messengerService = service;
        }

        public void AddNewProfile(IList<Profile> collection)
        {
            DataLoadingService dls = new DataLoadingService();
            collection.Add(new Profile()
            {
                ID = dls.GenerateID()
            });
            messengerService.Send("ADD OK", "LogicResult");
        }

        public void AddExistingProfile(IList<Profile> collection, Profile toBeAdded)
        {
            collection.Add(toBeAdded);
            messengerService.Send("ADD OK", "LogicResult");
        }

        public void RemoveProfile(IList<Profile> collection, Profile toBeRemoved)
        {
            collection.Remove(toBeRemoved);
            messengerService.Send("DEL OK", "LogicResult");
        }
    }
}
