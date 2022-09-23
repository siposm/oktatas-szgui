using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop06.Model
{
    public class GameModel : IGameModel
    {

        public RectangleType[,] GameState { get; set; }

        public GameModel()
        {
            GameState = new RectangleType[3, 3];
            ;
        }

    }
}
