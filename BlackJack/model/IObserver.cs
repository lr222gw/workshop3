using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface IObserver
    {
        void update(Card c);
    }
}
