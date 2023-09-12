using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    /// <summary>
    /// <c>Player</c> models the player.
    /// </summary>
    public struct Player
    {
        //attributes
        public List<Card> _cards;
        public bool stand;
        
        //Constructor
        public Player(bool isHand)
        {
            _cards = new List<Card>();
            stand = false;
        }
        
        //Property
        public List<Card> Cards
        {
            get { return _cards; }
            private set { _cards = value; }
        }

        /// <summary>
        /// Get the sum of the players hand in BlackJack values.
        /// </summary>
        /// <returns></returns>
        public int BlackJackSum()
        {
            int handValue = 0;
            //check each card for it's value and add it to the hand value.
            for (int i = 0; i < _cards.Count; i++)
            {
                //the cards 2 through 10 is the values on the cards.
                if (_cards[i].OValue > 1 && _cards[i].OValue < 11)
                {
                    handValue += _cards[i].OValue;
                }
                else if (_cards[i].OValue != 1) //the cards 11 through 13 is 10.
                {
                    handValue += 10;
                }
                else if (handValue + _cards[i].OValue > 21) //if adding the ace would become more than 21, it is 1
                {
                    handValue += 1;
                }
                else //else the ace is 11.
                {
                    handValue += 11;
                }
            }
            return handValue;
        }

        /// <summary>
        /// Set the players hand to stand.
        /// </summary>
        public void Stand()
        {
            stand = true;
        }

        /// <summary>
        /// Add one card to the players hand.
        /// </summary>
        /// <param name="card"></param>
        public void Hit(Card card)
        {
            _cards.Add(card);
        }
    }
}
