using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface ISubject
    {
        void register(IObserver observer);
        void notify(Card a_card);
    }
}
