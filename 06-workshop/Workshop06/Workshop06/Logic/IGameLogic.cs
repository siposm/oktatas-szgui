using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop06.Model;

namespace Workshop06.Logic
{
    public interface IGameLogic
    {

        public void HandleStep(ClickData coordinate);

    }
}
