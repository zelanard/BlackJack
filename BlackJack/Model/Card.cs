using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    /// <summary>
    /// <c>Card</c> models a Card.
    /// </summary>
    public struct Card
    {
        //Attributes
        private int _oValue;
        private Suit _suit;
        
        //Constructor
        public Card(int oValue, int suit) : this()
        {
            OValue = oValue;
            Suit = (Suit)suit;
        }
        
        //properties
        public int OValue
        {
            get { return _oValue; }
            set { _oValue = value; }
        }
        internal Suit Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }
        
        /// <summary>
        /// Print the card.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (this.OValue)
            {
                case 1:
                    return $"Ace of {Suit}";
                case 11:
                    return $"Jack of {Suit}";
                case 12:
                    return $"Queen of {Suit}";
                case 13:
                    return $"King of {Suit}";
                default:
                    return $"{OValue} of {Suit}";
            }
        }
    }
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
}
