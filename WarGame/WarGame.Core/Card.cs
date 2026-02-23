using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Card
    {
        public Suit.Suits Suit { get; private set; }
        public Rank.Ranks Rank { get; private set; }
        public Card(Suit.Suits suit, Rank.Ranks rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
