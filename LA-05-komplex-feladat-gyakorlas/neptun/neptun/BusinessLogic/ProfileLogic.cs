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

        public void AddProfile(IList<Profile> collection, Profile toBeAdded)
        {
            // itt lehetne előtte sok féle/fajta vizsgálat, szűrés, stb. >> ezért van külön LOGIC-ba kiszervezve
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
