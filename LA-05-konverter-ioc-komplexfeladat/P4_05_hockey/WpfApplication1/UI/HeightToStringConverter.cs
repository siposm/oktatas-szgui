using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication1.UI
{
    class HeightToStringConverter : IValueConverter // ONLY if enough time
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int h = (int)value;
            return string.Format("{0}m {1}cm", h / 100, h % 100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // no Validation
            string[] input = value.ToString().Split(' ');
            int m = int.Parse(input[0].Substring(0, input[0].Length - 1));
            int cm = int.Parse(input[1].Substring(0, input[1].Length - 2));
            return m * 100 + cm;
        }
    }
}
