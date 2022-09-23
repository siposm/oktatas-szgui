using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop07.Model
{
    internal class GameModel : IGameModel
    {
        public Ball Ball { get; set; }
        public Wall LeftWall { get; set; }
        public Wall RightWall { get; set; }
        public Wall TopWall { get; set; }
        public Pad Pad { get; set; }
    }
}
