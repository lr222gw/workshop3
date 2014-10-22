﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;

        // EGEN KOD
        private rules.IWinnerStrategy m_winnerRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();

            // EGEN KOD
            m_winnerRule = a_rulesFactory.GetWinnerRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                //Card c = m_deck.GetCard();
                //c.Show(true);
                //DealCard(c);
                Card c = dealCard();
                a_player.DealCard(c);

                return true;
            }
            return false;
        }
        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerRule.IsDealerWinner(a_player, this, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            // VÅRAN KOD
            if (m_deck != null)
            {
                ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    //Card c = m_deck.GetCard();
                    //c.Show(true);
                    //DealCard(c);
                    dealCard();
                }

                return true;
            }

            return false;
        }
        private Card dealCard()
        {
            Card c = m_deck.GetCard();
            c.Show(true);
            DealCard(c);
            return c;
        }
    }
}
