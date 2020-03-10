using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.BL;
using WpfApplication1.Data;

namespace WpfApplication1.UI
{
    // IEditorService: dependency 2 layers down
    // Interface dependency + not really layer-bound
    class EditorServiceViaWindow : IEditorService
    {
        public bool EditPlayer(Player p)
        {
            EditorWindow win = new EditorWindow(p);
            return win.ShowDialog() ?? false;
        }
    }
}
