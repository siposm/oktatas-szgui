using ArmyEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyEditor.Services
{
    public class TrooperEditorViaWindow : ITrooperEditorService
    {
        public void Edit(Trooper trooper)
        {
            new TrooperEditorWindow(trooper).ShowDialog();
        }
    }
}
