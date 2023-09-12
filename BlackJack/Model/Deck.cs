using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    /// <summary>
    /// <c>Deck</c> models the deck.
    /// </summary>
    public struct Deck
    {
        // field
        public List<Card> _cards;
        
        //Constructor
        public Deck(bool shuffle)
        {
            _cards = GenerateDeck().ToList();
            ShuffleDeck();
        }

        /// <summary>
        /// Generate the cards for the deck.
        /// </summary>
        /// <returns></returns>
        private static Card[] GenerateDeck()
        {
            Card[] c = new Card[52];
            int cardIndex = 1;

            for (int rank = 1; rank < 13; rank++)
            {
                for (int suit = 0; suit < 4; suit++)
                {
                    c[cardIndex] = new Card(rank, suit);
                    cardIndex++;
                }
            }

            return c;
        }
        /// <summary>
        /// Shuffle the deck. <br/>
        /// The shuffling is acomplished by swaping the positions of cards, 52 x 4 times.
        /// </summary>
        private void ShuffleDeck()
        {
            Random random = new Random();
            int n = _cards.Count;

            for (int t = 0; t < 4; t++)
            {
                //i can never be greater than the number of cards in the deck.
                //If i was > 52, it would be out of bounds.
                for (int i = 0; i < n - 1; i++)
                {
                    int j = random.Next(i, n);
                    // Swap _cards[i] and _cards[j]
                    Card temp = _cards[i];
                    _cards[i] = _cards[j];
                    _cards[j] = temp;
                }
            }
        }
    }

}
