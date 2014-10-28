using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        // m eller a???
        model.Game a_game;
        view.IView a_view;

        public bool Play(model.Game a_game, view.IView a_view)
        {
            // TEST
            this.a_game = a_game;
            this.a_view = a_view;

            // VÅR KOD
            model.Dealer dealer = a_game.getDealer();
            dealer.RegisterObserver(this);

            // VÅR KOD
            model.Player player = a_game.getPlayer();
            player.RegisterObserver(this);

            //a_view.DisplayWelcomeMessage();
            
            //a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            //a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            //if (a_game.IsGameOver())
            //{
            //    a_view.DisplayGameOver(a_game.IsDealerWinner());
            //}

            ShowGame();
            
            int input = a_view.GetInput();

            if (input == (char)view.Choice.Play)
            {
                a_game.NewGame();
            }
            else if (input == (char)view.Choice.Hit)
            {
                a_game.Hit();
            }
            else if (input == (char)view.Choice.Stand)
            {
                a_game.Stand();
            }

            // VÅR KOD
            dealer.RemoveObserver(this);
            player.RemoveObserver(this);

            return input != (char)view.Choice.Quit;
        }
  
        // VÅR KOD
        public void UpdateObserver() {
            ShowGame();
            Thread.Sleep(1500);
        }

        // VÅR REFACTORING
        private void  ShowGame() {
            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }
        }
    }
}
