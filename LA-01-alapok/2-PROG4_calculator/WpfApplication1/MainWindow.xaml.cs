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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        //  System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator

        public MainWindow()
        {
            InitializeComponent();
        }

        // Rename = F2 or CTRL+R+R
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            // STEP 1 = multiple controls, single event associated
            //txtCurrent.Text += (sender as Button).Content.ToString();
        }

        private void DecSep_Click(object sender, RoutedEventArgs e)
        {
            if (!txtCurrent.Text.Contains(decSep))
            {
                txtCurrent.Text += decSep;
            }
        }

        private void Oper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblOper.Content = (sender as Button).Content.ToString()[0];
                lblOp1.Content = double.Parse(txtCurrent.Text);
                txtCurrent.Text = String.Empty;
            }
            catch (Exception ex) // UGLY hack
            {
                MessageBox.Show("Convert error: " + ex.Message);
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblOp2.Content = double.Parse(txtCurrent.Text);
                double op1 = (double)lblOp1.Content;
                double op2 = (double)lblOp2.Content;
                switch ((char)lblOper.Content)
                {
                    case '+': lblResult.Content = op1 + op2; break;
                    case '-': lblResult.Content = op1 - op2; break;
                    case '*': lblResult.Content = op1 * op2; break;
                    case '/': lblResult.Content = op1 / op2; break;
                }
                txtCurrent.Text = lblResult.Content.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Convert error: " + ex.Message);
            }
        }

        // STEP 2 = multiple controls, routed event handled in parent
        private void NewNumber_Click(object sender, RoutedEventArgs e)
        {
            txtCurrent.Text += (e.Source as Button).Content.ToString();
        }

        // STEP 3 = preview events
        private void txtCurrent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text[0]) && (e.Text != decSep || e.Text == decSep && (sender as TextBox).Text.Contains(decSep));
        }

        private void txtCurrent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }
    }
}