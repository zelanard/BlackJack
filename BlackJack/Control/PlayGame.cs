using BlackJack.Model;
using System;

namespace BlackJack.Control
{
    /// <summary>
    /// Controls the game of BlackJack.
    /// </summary>
    public struct PlayBlackJack
    {
        //fields
        public static Deck deck = new Deck(true);
        public Player playerHand;
        public Player aIHand;

        /// <summary>
        /// Runs the game of black jack
        /// </summary>
        public void Start()
        {
            Random rnd = new Random();
            while (true)
            {
                View.View.PlayAGame();
                playerHand = new Player(true);
                aIHand = new Player(true);
                deck = new Deck(true);

                //deal to the player and the dealer.
                Deal(deck, playerHand);
                Deal(deck, aIHand);


                while (true)
                {
                    View.View.PrintHand(playerHand.BlackJackSum());
                    View.View.PrintOpponent(aIHand);
                    
                    //if the player have not yet stood, let them play.
                    if (!playerHand.stand)
                    {
                        if (playerHand.BlackJackSum() < 21) //if the player have less than 21, let them chose if they want to draw.
                        {
                            PlayerMayDraw();
                        }
                        else if (playerHand.BlackJackSum() == 21) //if the player have 21, they have black jack and must stand.
                        {
                            View.View.BlackJack();
                            playerHand.Stand();
                            continue;
                        }
                        else //if the player have more than 21, they are busted.
                        {
                            View.View.Bust(playerHand.BlackJackSum());
                            break;
                        }
                    }

                    //If the dealer have more than 16 points, it stands.
                    if (!aIHand.stand)
                    {
                        DealersTurn();
                    }

                    // when both players have chosen to stand, check who the winner is.
                    if (aIHand.stand && playerHand.stand)
                    {
                        GetWinner();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// The player may draw a card or chose to stand.
        /// </summary>
        private void PlayerMayDraw()
        {
            if (View.View.DrawCard())
            {
                playerHand.Hit(deck._cards[0]);
                deck._cards.RemoveAt(0);
            }
            else
            {
                playerHand.Stand();
            }
        }

        /// <summary>
        /// The dealer takes it's turn.
        /// </summary>
        private void DealersTurn()
        {
            if (aIHand.BlackJackSum() < 16)
            {
                aIHand.Hit(deck._cards[0]);
                deck._cards.RemoveAt(0);
            }
            else
            {
                aIHand.Stand();
            }
        }

        /// <summary>
        /// check who the winner is
        /// </summary>
        private void GetWinner()
        {
            View.View.PrintHand(playerHand.BlackJackSum());
            View.View.PrintOpponent(aIHand);
            //if the player have a higher score than the dealer, the player wins
            if (playerHand.BlackJackSum() > aIHand.BlackJackSum())
            {
                View.View.PlayerWin();
            }
            else if (aIHand.BlackJackSum() < 22) //if the dealer have less than 22 and a higher score than the player, the delaer wins.
            {
                View.View.DealerWin();
            }
            else //if the dealer have a higher score than 21, the player wins.
            {
                View.View.PlayerWin();
            }
        }

        /// <summary>
        /// deal the cards.
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="hand"></param>
        public void Deal(Deck deck, Player hand)
        {
            for (int i = 0; i < 2; i++)
            {
                hand.Hit(deck._cards[i]);
                deck._cards.RemoveAt(i);
            }
        }
    }
}
