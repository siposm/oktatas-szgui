using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop06.Service
{
    public interface IGameOverService
    {

        public void DoPlayerWin();

        public void DoEnemyWin();

        public void DoTie();

    }
}
