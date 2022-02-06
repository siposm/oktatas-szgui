using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Windows.Media;
using WpfApplication1.Data;

namespace WpfApplication1.UI
{
    class StatusToBrushConverter : IValueConverter // ONLY if enough time
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StatusType pos = (StatusType)value;
            switch (pos)
            {
                default:
                case StatusType.Active: return Brushes.LightGreen;
                case StatusType.Injured: return Brushes.Salmon;
                case StatusType.SentToMinors: return Brushes.LightGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            return Binding.DoNothing;
        }
    }
}
