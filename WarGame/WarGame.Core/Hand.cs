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
        /// 
        /// </summary>
        public Queue<Card> Cards { get; } = new Queue<Card>();

        /// <summary>
        /// 
        /// </summary>
        public bool HasCards => Cards.Count > 0;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Card PlayCard() => Cards.Dequeue();

        /// <summary>
        /// 
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
