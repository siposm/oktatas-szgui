using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Workshop06.Renderer;

namespace Workshop06.Service
{
    public class GameOverServiceViaMessageBox : IGameOverService
    {

        private Display display;

        public GameOverServiceViaMessageBox(Display display)
        {
            this.display = display;
        }

        public void DoEnemyWin()
        {
            display.InvalidateVisual();
            MessageBox.Show("Enemy won!");
            Application.Current.Shutdown();
        }

        public void DoPlayerWin()
        {
            display.InvalidateVisual();
            MessageBox.Show("You won!");
            Application.Current.Shutdown();
        }

        public void DoTie()
        {
            display.InvalidateVisual();
            MessageBox.Show("Tie!");
            Application.Current.Shutdown();
        }
    }
}
