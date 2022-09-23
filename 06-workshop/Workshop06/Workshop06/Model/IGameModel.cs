using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop06.Model
{
    public interface IGameModel
    {

        public RectangleType[,] GameState { get; set; }

    }
}
