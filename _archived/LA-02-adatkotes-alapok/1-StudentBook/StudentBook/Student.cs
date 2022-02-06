using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBook
{
    public class Student
    {
        public string Name { get; set; }
        public string NeptunCode { get; set; }
        public int? EnrollmentYear { get; set; } // nullable option (ezt végül nem használtuk, a json miatt sima int-et használtunk, de a datepicket amúgy datetime object-et kezelne
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

        // unit test
        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student x = obj as Student;
                return
                    this.Name == x.Name &&
                    this.NeptunCode == x.NeptunCode &&
                    this.EnrollmentYear == x.EnrollmentYear &&
                    this.IsActive == x.IsActive;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (Name?.GetHashCode() ?? 0) + (NeptunCode?.GetHashCode() ?? 0);
            // https://docs.microsoft.com/hu-hu/dotnet/csharp/language-reference/operators/null-coalescing-operator
        }

        public void CopyFrom(Student source)
        {
            this.Name = source.Name;
            this.NeptunCode = source.NeptunCode;
            this.EnrollmentYear = source.EnrollmentYear;
            this.IsActive = source.IsActive;
        }
    }
}
