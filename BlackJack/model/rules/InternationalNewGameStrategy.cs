using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            a_dealer.DealCardTo(a_player);
            a_dealer.DealCardTo(a_dealer);
            a_dealer.DealCardTo(a_player);

            return true;
        }
    }
}
