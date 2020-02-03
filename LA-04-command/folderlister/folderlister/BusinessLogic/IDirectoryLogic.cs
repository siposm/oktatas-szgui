using folderlister.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folderlister.BusinessLogic
{
    interface IDirectoryLogic
    {
        IEnumerable<DirectoryEntry> CollectDirectoryEntries(string currentDirectory);

        void SelectEntry(DirectoryEntry entry);
    }
}
