using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample
{
    public class CounterLogic : ICounterLogic
    {
        IMessenger messenger;

        public int Counter { get; set; }

        public void Increase()
        {
            Counter++;
            messenger.Send("Counter changed", "CounterResult");
        }

        public CounterLogic(IMessenger messenger)
        {
            this.messenger = messenger;
            Counter = 1;
        }
    }
}
