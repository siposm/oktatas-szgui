using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Workshop06.Model;

namespace Workshop06.Controller
{
    internal interface IGameController
    {

        public void CoordinateClicked(Point p, double areaTotalWidth, double areaTotalHeight);

    }
}
