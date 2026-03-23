using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Deck
    {   /// <summary>
        /// Stack to hold the cards in the deck
        /// </summary>
        private Stack<Card> Cards = new Stack<Card>();

        /// <summary>
        /// Constructor to initialize the deck with 52 cards and shuffle them
        /// </summary>
        public Deck() 
        { 
            var cardList = new List<Card>();
            foreach (Suits s in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
                {
                    cardList.Add(new Card(s, r));
                }
            }
            //shuffler
            var rng = new Random();
            cardList = cardList.OrderBy(x => rng.Next()).ToList();

            // pushes cards to the stack
            foreach (var card in cardList)
            {
                Cards.Push(card);
            }
        }

        /// <summary>
        /// Determines whether the collection contains any cards.
        /// </summary>
        /// <returns>true if the collection contains at least one card; 
        /// otherwise, false.</returns>
        public bool Any() => Cards.Count > 0;

        /// <summary>
        /// Gives the top card from the deck and removes it from the stack.
        /// </summary>
        /// <returns>top card to </returns>
        public Card Draw() => Cards.Pop();
    }
}
