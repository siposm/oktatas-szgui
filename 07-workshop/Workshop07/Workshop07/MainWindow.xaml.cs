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
using System.Windows.Threading;
using Workshop07.Control;
using Workshop07.Model;

namespace Workshop07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt;

        IGameControl control;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Hidden dependencies mehh....
            var model = new GameModel();
            var logic = new GameLogic((int)grid.ActualWidth, (int)grid.ActualHeight, model);
            display.SetupModel(model);
            display.InvalidateVisual();
            SetupTimer(logic);
        }

        private void SetupTimer(IGameLogic logic)
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Tick += (sender, eventargs) =>
            {
                logic.TimeStep();
                display.InvalidateVisual();
            };
            dt.Start();
            control = new GameControl(logic);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var model = new GameModel();
            var logic = new GameLogic((int)grid.ActualWidth, (int)grid.ActualHeight, model);
            control = new GameControl(logic);
            display.SetupModel(model);
            display.InvalidateVisual();
            SetupTimer(logic);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            control.KeyDown(e.Key);
        }
    }
}
