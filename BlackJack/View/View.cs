using BlackJack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.View
{
    /// <summary>
    /// Controls the CLI.
    /// </summary>
    public static class View
    {
        /// <summary>
        /// print the players hand.
        /// </summary>
        /// <param name="hand"></param>
        public static void PrintHand(int hand)
        {
            Console.WriteLine($"Your hand is: {hand}");
        }
        
        /// <summary>
        /// print the dealers card or hand.
        /// </summary>
        /// <param name="cards"></param>
        public static void PrintDealer(Player cards, bool pStand)
        {
            if (cards.stand && pStand)
            {
                Console.WriteLine($"Dealer has: {cards.BlackJackSum()}");
            }
            else
            {
                Console.WriteLine($"Dealer has: {cards._cards[0]}");
            }
        }
        
        /// <summary>
        /// prompt the player to draw a card or stand.
        /// </summary>
        /// <returns></returns>
        public static bool DrawCard()
        {
            Console.WriteLine("Do you wish to Draw or Stand? (D/S)");
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D)
                {
                    return true;
                }
                else if (key == ConsoleKey.S)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
        }
        
        /// <summary>
        /// the player has Black Jack.
        /// </summary>
        public static void BlackJack()
        {
            Console.WriteLine("You have BlackJack!");
        }
        
        /// <summary>
        /// The player wins the game.
        /// </summary>
        public static void PlayerWin()
        {
            Console.WriteLine("Congratulations! You win the game!");
            Console.ReadKey();
        }
        
        /// <summary>
        /// The dealer wins the game.
        /// </summary>
        public static void DealerWin()
        {
            Console.WriteLine("The Dealer win the game!");
            Console.ReadKey();
        }
        
        /// <summary>
        /// The player is busted.
        /// </summary>
        /// <param name="busted"></param>
        public static void Bust(int busted)
        {
            Console.WriteLine($"You have {busted} and are Busted!");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the player to play a game of BlackJack.
        /// </summary>
        /// <returns></returns>
        public static bool PlayAGame()
        {
            Console.Clear();
            Console.WriteLine($"Do you wish to play a game of BlackJack? (Y/N)");
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    return true;
                }
                else if (key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
