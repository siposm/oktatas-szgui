using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neptun.Model
{
    class Profile : ObservableObject
    {
        private string id;
        public string ID
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private int birthYear;
        public int BirthYear
        {
            get { return birthYear; }
            set { Set(ref birthYear, value); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { Set(ref image, value); }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { Set(ref isActive, value); }
        }

        private int activeSemesterCount;
        public int ActiveSemesterCount
        {
            get { return activeSemesterCount; }
            set { Set(ref activeSemesterCount, value); }
        }

        private int connections;
        public int Connections
        {
            get { return connections; }
            set { Set(ref connections, value); }
        }

        private int completedCredits;
        public int CompletedCredits
        {
            get { return completedCredits; }
            set { Set(ref completedCredits, value); }
        }

        public int Hash
        {
            get { return Math.Abs(this.GetHashCode()); }
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode() * ID.GetHashCode();

            //return ID.GetHashCode() * Name.GetHashCode();
            // error: System.ArgumentException: 'An item with the same key has already been added.'
            // explanation: https://stackoverflow.com/questions/15966949/wpf-datagrid-item-with-the-same-key-has-already-been-added
        }

        public override bool Equals(object obj)
        {
            if (obj is Profile)
            {
                Profile x = obj as Profile;
                return x.ID == ID &&
                    x.Name == Name &&
                    x.BirthYear == BirthYear &&
                    x.IsActive == IsActive;
            }
            return false;
        }

        public void CopyFrom(Profile other)
        {
            // WARNING: creates shallow copy - no problem for now
            // WARNING: reflection is SLOOOOOOOOW - no problem for now
            // Possible: using AutoMapper;
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
