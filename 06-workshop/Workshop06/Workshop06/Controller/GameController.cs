using System;
using System.Windows;
using Workshop06.Logic;
using Workshop06.Model;

namespace Workshop06.Controller
{
    public class GameController : IGameController
    {
        IGameLogic logic;
        public GameController(IGameLogic logic)
        {
            this.logic = logic;
        }

        public void CoordinateClicked(Point p, double areaTotalWidth, double areaTotalHeight)
        {
            logic.HandleStep(new ClickData() { X = p.X, Y = p.Y, TotalWidth = areaTotalWidth, TotalHeight = areaTotalHeight });
        }
    }
}
