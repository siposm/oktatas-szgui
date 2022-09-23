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
using Workshop06.Controller;
using Workshop06.Logic;
using Workshop06.Model;
using Workshop06.Service;

namespace Workshop06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGameController controller;

        public MainWindow()
        {
            InitializeComponent();
            // Ugly hidden dependencies, IoC would be the correct way, but that's not the scope now.
            GameModel model = new GameModel();
            display.SetupModel(model);
            // Ugly hack, passing the renderer to the service... If we don't do that, we can't see the last step before the win message box.
            // Better option would be: add Mediator pattern. Model tells the mediator that the state changed, renderer listens to the mediator.
            IGameOverService service = new GameOverServiceViaMessageBox(display);
            IGameLogic logic = new GameLogic(model, service);
            controller = new GameController(logic);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(grid);
            controller.CoordinateClicked(p, grid.ActualWidth, grid.ActualHeight);
            display.InvalidateVisual();
        }
    }
}
