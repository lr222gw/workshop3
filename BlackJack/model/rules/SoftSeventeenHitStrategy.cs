using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if(a_dealer.CalcScore() < g_hitLimit) {
                return true;
            }
            else if (a_dealer.CalcScore() == g_hitLimit)
            {



                IEnumerable<Card> hand = a_dealer.GetHand();



                bool hasAce = false;

                foreach (Card c in hand)
                {

                    if (c.GetValue() == Card.Value.Ace)
                    {
                        //
                    }

                        
                }




            }

            return false;
        }
    }
}
