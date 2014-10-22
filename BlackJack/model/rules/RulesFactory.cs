using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            //return new BasicHitStrategy();
            
            // VÅRAN KOD
            return new SoftSeventeenHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        // VÅRAN KOD
        public IWinnerStrategy GetWinnerRule()
        {
            return new PlayerWinsOnEqualStrategy();
        }


    }
}
