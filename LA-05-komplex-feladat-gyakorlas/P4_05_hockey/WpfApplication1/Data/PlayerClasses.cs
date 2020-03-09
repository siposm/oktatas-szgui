using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;

namespace WpfApplication1.Data
{
    // All public!
    // Player will be a ctor param in a window, thats why
    // Should be separated: business model VS view model VS dto ...
    public enum PositionType
    {
        Center,
        Back,
        LeftWing,
        RightWing,
        Goalie
    }
    public enum StatusType
    {
        Active,
        Injured,
        SentToMinors
    }
    public class Player : ObservableObject
    {
        int height;
        PositionType position;
        StatusType status;
        string name;

        public int Height
        {
            get { return height; }
            set { Set(ref height, value); }
        }
        public StatusType Status
        {
            get { return status; }
            set { Set(ref status, value); }
        }
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }
        public PositionType Position
        {
            get { return position; }
            set { Set(ref position, value); }
        }

        public void CopyFrom(Player other)
        {
            // WARNING: creates shallow copy - no problem for now
            // WARNING: reflection is SLOOOOOOOOW - no problem for now
            // Possible: using AutoMapper;
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }
    }
}