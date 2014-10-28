using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            // VÅR KOD
            model.Dealer dealer = a_game.getDealer();
            dealer.RegisterObserver(this);

            // VÅR KOD
            model.Player player = a_game.getPlayer();
            player.RegisterObserver(this);

            a_view.DisplayWelcomeMessage();
            
            // Move these rows to UpdateObserver
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

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
            //TODO: Update SwedishView, IView, SimpleView

            Console.Out.WriteLine("TEST");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
