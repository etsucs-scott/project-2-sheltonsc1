using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public enum Suits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Ranks
    {
       Two = 2,
       Three = 3,
       Four = 4,
       Five = 5,
       Six = 6,
       Seven = 7,
       Eight = 8,
       Nine = 9,
       Ten = 10,
       Jack = 11,
       Queen = 12,
       King = 13,
       Ace = 14
    }

    /// <summary>
    /// Represents a standard playing card with a suit and rank.
    /// </summary>
    public class Card : IComparable<Card>
    {
        public Suits Suit { get; }

        public Ranks Rank { get; }

        /// <summary>
        /// Initializes a new instance of the Card class with the 
        /// specified suit and rank.
        /// </summary>
        /// <param name="suit">The suit of the card.</param>
        /// <param name="rank">The rank of the card.</param>
        public Card(Suits suit, Ranks rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Compares the current card to another card based on their ranks.
        /// </summary>
        /// <param name="card">The card to compare with the current card. Can be null.</param>
        /// <returns>A value less than zero if the current card has a lower rank than the compared to card; zero if the ranks
        /// are equal; a value greater than zero if the current card has a higher rank.</returns>
        public int CompareTo(Card? card)
        {
            if (card == null) return 1; // Current card is greater than null
            return Rank.CompareTo(card.Rank);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
