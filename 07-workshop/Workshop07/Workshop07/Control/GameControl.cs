using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Workshop07.Control
{
    internal class GameControl : IGameControl
    {
        private IGameLogic _logic;

        public GameControl(IGameLogic logic)
        {
            _logic = logic;
        }

        public void KeyDown(Key k)
        {
            switch(k)
            {
                case Key.Right:
                    _logic.PadStep(Direction.RIGHT);
                    break;
                case Key.Left:
                    _logic.PadStep(Direction.LEFT);
                    break;
            }
        }
    }
}
