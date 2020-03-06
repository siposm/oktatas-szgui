using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neptun.Model
{
    class Profile
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int ActiveSemesterCount { get; set; }
        public int Connections { get; set; }
        public int CompletedCredits { get; set; }
    }
}
