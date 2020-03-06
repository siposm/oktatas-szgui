﻿using neptun.BusinessLogic;
using neptun.ViewModel;
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
using System.Windows.Shapes;

namespace neptun
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // passwordbox-ot nem lehet adatkötni különböző biztonsággal kapcsolatos okok miatt, ezért maradt az old-fashioned-way
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            LoginValidatorService lvs = new LoginValidatorService();
            try
            {
                if (lvs.ValidateCredentials(input_username.Text, lvs.GenerateHash(input_password.Password)))
                {
                    // open main window
                    //MessageBox.Show("OK"); // teszt
                    MainWindow mw = new MainWindow();
                    MainWindowViewModel vm = new MainWindowViewModel();
                    mw.DataContext = vm;
                    mw.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                    exc.Message,
                    "ERROR",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
