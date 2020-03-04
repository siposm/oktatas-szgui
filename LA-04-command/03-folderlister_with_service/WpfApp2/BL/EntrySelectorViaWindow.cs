using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.BL;

namespace WpfApp2.VM
{
    class EntrySelectorViaWindow : IEntrySelectorService
    {
        public void SelectEntry(DirectoryEntry entry)
        {
            if (entry == null) return;
            if (entry.IsDir)
            {
                MainWindow window = new MainWindow(entry.Name);
                window.Show();
            }
            else
            {
                System.Diagnostics.Process.Start(entry.Name);
            }
        }
    }
}
