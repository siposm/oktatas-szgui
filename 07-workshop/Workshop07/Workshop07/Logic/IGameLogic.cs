using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop07
{
    internal interface IGameLogic
    {
        public void PadStep(Direction direction);

        public void TimeStep();
    }
}
