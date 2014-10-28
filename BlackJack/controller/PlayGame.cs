using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        model.Game m_game;
        view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
        }

        public bool Play()
        {
            model.Dealer dealer = m_game.getDealer();
            dealer.RegisterObserver(this);

            model.Player player = m_game.getPlayer();
            player.RegisterObserver(this);
            
            ShowGame();
            
            int input = m_view.GetInput();

            if (input == (char)view.Choice.Play)
            {
                m_game.NewGame();
            }
            else if (input == (char)view.Choice.Hit)
            {
                m_game.Hit();
            }
            else if (input == (char)view.Choice.Stand)
            {
                m_game.Stand();
            }

            dealer.RemoveObserver(this);
            player.RemoveObserver(this);

            return input != (char)view.Choice.Quit;
        }

        private void ShowGame()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }

        public void UpdateObserver() {
            ShowGame();
            Thread.Sleep(1000);
        }
    }
}
