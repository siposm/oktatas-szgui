using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folderlister.Model
{
    class DirectoryEntry
    {
        public string Name { get; set; }
        public bool IsDir { get; set; }

        public override string ToString()
        {
            return IsDir ? String.Format("[{0}]", Name) : Name;
        }

        public DirectoryEntry(string name, bool dir)
        {
            Name = name; IsDir = dir;
        }
    }
}
