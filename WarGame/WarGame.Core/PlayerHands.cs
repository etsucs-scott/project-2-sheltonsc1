using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class PlayerHands
    {
        /// <summary>
        /// creates a dictionary to hold the player's name and their hand of cards
        /// </summary>
        private readonly Dictionary<string, Hand> hands = new();

        /// <summary>
        /// where the player's name is the key and the value is their hand of cards
        /// </summary>
        public IEnumerable<string> PlayerNames => hands.Keys;

        /// <summary>
        /// constructor to identify the players and give them their hand of cards
        /// </summary>
        /// <param name="player"></param>
        /// <returns>a player with a hand of cards</returns>
        public Hand this[string player] => hands[player];

        /// <summary>
        /// adds a player to the game by creating a new hand of cards for them and adding it to the dictionary
        /// </summary>
        /// <param name="name"></param>
        public void AddPlayer(string name)
        {
            hands[name] = new Hand(new Queue<Card>());
        }

        /// <summary>
        /// verifies whether a hand with the specified name exists in the collection.
        /// </summary>
        /// <param name="name">The name of the hand to locate in the collection. Cannot be null.</param>
        /// <returns>true if a hand with the specified name exists in the collection; otherwise, false.</returns>
        public bool Contains(string name) => hands.ContainsKey(name);

        /// <summary>
        /// removes a player from the game by removing their hand of cards from the dictionary
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name) => hands.Remove(name);

        /// <summary>
        /// Gets the collection of player names who currently have cards in hand.
        /// </summary>
        public IEnumerable<string> ActivePlayers => hands.Where(p => p.Value.HasCards).Select(p => p.Key);

        /// <summary>
        /// counts the number of players in the game by counting the number of "hands" in the dictionary
        /// </summary>
        public int Count => hands.Count;

        /// <summary>
        /// Gets a dictionary containing the number of cards held by each player.
        /// </summary>
        public Dictionary<string, int> CardCounts => hands.ToDictionary(p => p.Key, p => p.Value.Cards.Count);
    }
}
