using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace netPriceCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string FormatMyString(string input)
        {
            if (input.Length == 4)
                return input[0] + " " + input[1] + input[2] + input[3];

            else if (input.Length == 5)
                return input[0] + input[1] + " " + input[2] + input[3] + input[4];

            else if (input.Length == 6)
                return input[0] + input[1] + input[2] + " " + input[3] + input[4] + input[5];

            else
                return input;
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            double bruttoPrice = double.Parse(txtBrutValue.Text);
            double VAT = double.Parse(txtTaxValue.Text); // 27 (%)

            double netPrice = bruttoPrice - (bruttoPrice * (VAT / 100));

            lblResult.Content = FormatMyString(netPrice.ToString());
        }
    }
}
