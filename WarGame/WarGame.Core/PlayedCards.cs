using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class PlayedCards
    {
        /// <summary>
        /// dictionary to hold the player's name and the card they played in the current round
        /// </summary>
        private readonly Dictionary<string, Card> played = new();

        /// <summary>
        /// adds a card to the dictionary of played cards for the current round, 
        /// using the player's name as the key and the card they played as the value
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        public void Add(string player, Card card)
        {
            played[player] = card;
        }

        /// <summary>
        /// tracker of cards played in the current round, 
        /// where the player's name is the key and the value is the card they played
        /// </summary>
        public IReadOnlyDictionary<string, Card> All => played;

        /// <summary>
        /// clears the dictionary of played cards for the current round
        /// </summary>
        public void Clear() => played.Clear();
    }
}
