using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace order_handler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] UsableCoupons
        {
            get
            {
                return new string[]
                {
                    "C101",
                    "C202",
                    "C30",
                    "C45",
                    "C990"
                };
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = String.Empty;

            try
            {
                //string name = txtName.Text;
                //string name = cmbNameSelector.SelectedItem.ToString();
                string name = cmbNameSelector.Text;
                int price = int.Parse(txtPrice.Text);
                int prepaid = int.Parse(txtPrepaid.Text);
                string coupon = txtCoupon.Text;
                int result = price - prepaid;

                if (result > 0)
                    s = "FIZETENDŐ: " + result;
                else if (result < 0)
                    s = "TÚLFIZETVE: " + (-result);
                else
                    s = "EGYENLEG RENDBEN";

                if (UsableCoupons.Contains(coupon))
                    s += "\n20% KEDVEZMÉNYRE JOGOSULT";
            }
            catch (FormatException ex) { s = "[ERR]: NOT A NUMBER"; }
            catch (OverflowException ex) { s = "[ERR]: TOO BIG NUMBER"; }

            lblResult.Content = s;
            MessageBox.Show(s);
        }

        #region SeparateButtonToSave
        // külön buttonnal mentünk txt-be
        private void ToTxtBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = String.Empty;
            try
            {
                //string name = txtName.Text;
                string name = cmbNameSelector.Text;
                int price = int.Parse(txtPrice.Text);
                int prepaid = int.Parse(txtPrepaid.Text);

                StreamWriter sw = new StreamWriter("order_output.txt");
                sw.WriteLine("USER: " + name);
                sw.WriteLine("PRICE: " + price + " HUF");
                sw.WriteLine("PREPAID: " + prepaid + " HUF");
                sw.Close();

                s = "SAVED TXT SUCCESSFULLY";
            }
            catch (FormatException ex) { s = "[ERR]: NOT A NUMBER"; }
            catch (OverflowException ex) { s = "[ERR]: TOO BIG NUMBER"; }

            lblResult.Content = s;
        }
        
        // külön buttonnal mentünk txt-be
        private void ToXmlBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = String.Empty;
            try
            {
                //string name = txtName.Text;
                string name = cmbNameSelector.Text;
                int price = int.Parse(txtPrice.Text);
                int prepaid = int.Parse(txtPrepaid.Text);

                XDocument xdoc = new XDocument();
                xdoc.Add(new XElement("root"));
                xdoc.Root.Add(
                    new XElement("user", name),
                    new XElement("price", price),
                    new XElement("prepaid", prepaid)
                    );

                xdoc.Save("output_as_xml.xml");

                s = "SAVED XML SUCCESSFULLY";
            }
            catch (FormatException ex) { s = "[ERR]: NOT A NUMBER"; }
            catch (OverflowException ex) { s = "[ERR]: TOO BIG NUMBER"; }

            lblResult.Content = s;
        }
        #endregion

        // létrehozunk két vagy több gombot, mindegyiknek ugyan azt az eseményt adjuk meg
        // ezt követően _itt_ vizsgáljuk, hogy "hogyan tovább"
        // A verzió: berakom egyből ide a SW és XDOC kódokat...
        private void ActionBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = String.Empty;
            try
            {
                //string name = txtName.Text;
                //string name = cmbNameSelector.SelectedItem.ToString();
                string name = cmbNameSelector.Text;
                int price = int.Parse(txtPrice.Text);
                int prepaid = int.Parse(txtPrepaid.Text);

                if ((e.Source as Button).Content.ToString().Contains("XML"))
                {
                    XDocument xdoc = new XDocument();
                    xdoc.Add(new XElement("root"));
                    xdoc.Root.Add(
                        new XElement("user", name),
                        new XElement("price", price),
                        new XElement("prepaid", prepaid)
                        );

                    xdoc.Save("output_as_xml.xml");

                    s = "SAVED XML SUCCESSFULLY";
                }
                else if ((e.Source as Button).Content.ToString().Contains("TXT"))
                {
                    StreamWriter sw = new StreamWriter("order_output.txt");
                    sw.WriteLine("USER: " + name);
                    sw.WriteLine("PRICE: " + price + " HUF");
                    sw.WriteLine("PREPAID: " + prepaid + " HUF");
                    sw.Close();

                    s = "SAVED TXT SUCCESSFULLY";
                }
            }
            catch (FormatException ex) { s = "[ERR]: NOT A NUMBER"; }
            catch (OverflowException ex) { s = "[ERR]: TOO BIG NUMBER"; }

            lblResult.Content = s;
        }

        // B verzió: továbbhívjuk a régi metódusokat
        private void ActionBtn_Click_v2(object sender, RoutedEventArgs e)
        {
            if ((e.Source as Button).Content.ToString().Contains("XML"))
                ToXmlBtn_Click(sender, e);

            else if ((e.Source as Button).Content.ToString().Contains("XML"))
                ToTxtBtn_Click(sender, e);
        }
    }
}
