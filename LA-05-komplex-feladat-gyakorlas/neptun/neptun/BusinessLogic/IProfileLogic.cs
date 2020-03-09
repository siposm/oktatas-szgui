using neptun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neptun.BusinessLogic
{
    interface IProfileLogic
    {
        void AddExistingProfile(IList<Profile> collection, Profile toBeAdded);
        void AddNewProfile(IList<Profile> collection);
        void RemoveProfile(IList<Profile> collection, Profile toBeRemoved);
    }
}
