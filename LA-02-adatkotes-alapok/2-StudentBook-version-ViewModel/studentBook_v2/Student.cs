using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentBook_v2
{
    public class Student
    {
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public int? EnrollmentYear { get; set; } // add nullable option
        public bool IsActive { get; set; }

        // tostring nem ideális... >> datatemplate "teljes" adatkötéshez
        public override string ToString()
        {
            string s = $"{Name} - [{NeptunCode}] : ";

            if (IsActive)
                s += "currently active";
            else
                s += "currently inactive";

            return s;
        }
    }
}
