using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BL
{
    class DirectoryLogic : IDirectoryLogic
    {
        IEntrySelectorService service;
        public DirectoryLogic(IEntrySelectorService service)
        {
            this.service = service;
        }

        public IEnumerable<DirectoryEntry> CollectDirectoryEntries(string currentDirectory)
        {
            var entries = new List<DirectoryEntry>();
            if (currentDirectory == string.Empty)
            {
                foreach (DriveInfo akt in DriveInfo.GetDrives())
                {
                    entries.Add(new DirectoryEntry(akt.Name, true));
                }
            }
            else
            {
                try
                {
                    foreach (string subDir in Directory.GetDirectories(currentDirectory))
                    {
                        entries.Add(new DirectoryEntry(subDir, true));
                    }
                    foreach (string file in Directory.GetFiles(currentDirectory))
                    {
                        entries.Add(new DirectoryEntry(file, false));
                    }
                }
                catch (Exception) // Boooo, evil! :) 
                {
                }
            }
            return entries;
        }

        public void SelectEntry(DirectoryEntry entry)
        {
            service.SelectEntry(entry); 
            // Extracted into a separated interface+class
            // To avoid the BL=>Window/MessageBox/Process dependency
            // This way, this dependency can be mocked
            // This is the ideal way
            // Can be skipped this semester, see next week
        }
    }
}
