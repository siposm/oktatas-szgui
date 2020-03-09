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
        void AddProfile(IList<Profile> collection, Profile toBeAdded);
        void RemoveProfile(IList<Profile> collection, Profile toBeRemoved);
    }
}
