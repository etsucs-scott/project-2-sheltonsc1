using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Hand
    {
        /// <summary>
        /// creates a queue to hold the cards in the player's hand
        /// </summary>
        public Queue<Card> Cards { get; } = new Queue<Card>();

        /// <summary>
        /// checks if the player has any cards in their hand
        /// </summary>
        public bool HasCards => Cards.Count > 0;

        /// <summary>
        /// creates a card to be played from the player's hand and removes it from the hand
        /// </summary>
        /// <returns></returns>
        public Card PlayCard() => Cards.Dequeue();

        /// <summary>
        /// constructor to intialize a hand of cards for a player to hold
        /// </summary>
        /// <param name="cards"></param>
        public Hand(Queue<Card> cards) 
        { 
            Cards = cards;
        }

        /// <summary>
        /// cards added to the player's hand 
        /// </summary>
        /// <param name="cards"></param>
        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (var c in cards)
            {
                Cards.Enqueue(c);
            }
        }

        public override string ToString()
        {
            return $"Hand with {Cards.Count} cards";
        }
    }
}
