using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsOnEqualStrategy : IWinnerStrategy
    {        
        public bool IsDealerWinner(Player a_player, Player a_dealer, int g_maxScore)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }

            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
        
    }
}
