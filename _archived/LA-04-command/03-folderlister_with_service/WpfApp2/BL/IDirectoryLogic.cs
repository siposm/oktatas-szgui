using System.Collections.Generic;

namespace WpfApp2.BL
{
    interface IDirectoryLogic
    {
        IEnumerable<DirectoryEntry> CollectDirectoryEntries(string currentDirectory);

        void SelectEntry(DirectoryEntry entry);
    }
}