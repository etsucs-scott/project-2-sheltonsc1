using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class WarGame
    {
        public PlayerHands PlayerHands { get; } = new();

        /// <summary>
        /// collection of cards that have been played in the current round and are at stake for the winner of the round.
        /// </summary>
        private readonly List<Card> pot = new();

        private const int RoundLimit = 10000;

        /// <summary>
        /// constructor to initialize the game by taking a list of player names, creating a hand of cards for each player, 
        /// and dealing the cards from a deck to the players in a round-robin fashion until the deck is empty
        /// </summary>
        /// <param name="players"></param>
        public WarGame(IEnumerable<string> players)
        {
            foreach (var p in players)
            {
                PlayerHands.AddPlayer(p);
            }
            DealCards(players.ToList());
        }

        /// <summary>
        /// deals cards from a deck to the players in a round-robin fashion until the deck is empty, 
        /// </summary>
        /// <param name="players">people playing the game</param>
        private void DealCards(List<string> players)
        {
            var deck = new Deck();
            int index = 0;
            while (deck.Any())
            {
                var player = players[index % players.Count];
                PlayerHands[player].Cards.Enqueue(deck.Draw());
                index++;
            }
        }

        /// <summary>
        /// intiates the game
        /// </summary>
        /// <returns>a possible winner</returns>
        public string PlayGame()
        {
            int round = 1;

            while (round <= RoundLimit)
            {
                var active = PlayerHands.ActivePlayers.ToList();

                if(active.Count == 1)
                {
                    return $"{active[0]} wins the game!";
                }
                Console.WriteLine($"\n--- Round {round}: ---");
                PlayRound(active);
                round++;
            }
            return DetermineWinnerByCount();
        }

        /// <summary>
        /// intitiates a round of play by having each active player play their top card.
        /// </summary>
        /// <param name="activePlayers">number of players actively playing the game</param>
        private void PlayRound(List<string> activePlayers)
        {
            pot.Clear();
            var played = new PlayedCards();

            foreach (var p in activePlayers)
            {
                var card = PlayerHands[p].PlayCard();
                played.Add(p, card);
                pot.Add(card);
                Console.WriteLine($"{p} plays {card}");
            }
            ResolveRound(played);
        }

        /// <summary>
        /// checks for a resoltuion to the round by comparing the ranks of the played cards. 
        /// If one player has the highest rank, they win the pot.
        /// also checks for ties and initiates a tiebreaker if necessary
        /// </summary>
        /// <param name="played">the played card</param>
        private void ResolveRound(PlayedCards played)
        {
            var maxRank = played.All.Values.Max(p => (int)p.Rank);
            var tied = played.All.Where(p => (int)p.Value.Rank == maxRank).Select(p => p.Key).ToList();

            if (tied.Count == 1)
            {
                AwardPot(tied[0]);
                return;
            }

            Console.WriteLine($"Tie was found between: " + string.Join(", ", tied));
            PlayTiebreaker(tied);
        }

        /// <summary>
        /// initiates a tiebreaker by having each tied player play another card. 
        /// If any player cannot continue, they are eliminated from the tiebreaker and 
        /// the remaining players continue until a winner is determined or all players are eliminated.
        /// </summary>
        /// <param name="tiedPlayers">number of tied player entering tiebreaker</param>
        private void PlayTiebreaker(List<string> tiedPlayers)
        {
            var played = new PlayedCards();
            foreach (var p in tiedPlayers.ToList())
            {
                if (!PlayerHands[p].HasCards)
                {
                    Console.WriteLine($"{p} cannot continue the tiebreaker and is eliminated!");
                    PlayerHands.Remove(p);
                    tiedPlayers.Remove(p);
                    continue;
                }
                var card = PlayerHands[p].PlayCard();
                played.Add(p, card);
                pot.Add(card);
                Console.WriteLine($"{p} plays {card} to win the tiebreaker!");
            }

            ///<summary>
            /// checks for multiple player still in tiebreaker scenario
            /// </summary>
            if (tiedPlayers.Count == 1)
            {
                AwardPot(tiedPlayers[0]);
                return;
            }
            ResolveRound(played);
        }

        /// <summary>
        /// awards the pot to the winner of the round by adding all the cards in the pot to their hand
        /// </summary>
        /// <param name="winner"></param>
        private void AwardPot(string winner)
        {
            Console.WriteLine($"{winner} has won the pot of {pot.Count} cards!");
            PlayerHands[winner].AddCards(pot);
        }

        /// <summary>
        /// determines the winner of the game by counting the number of cards each player has when the round limit (10000) is reached.
        /// </summary>
        /// <returns></returns>
        private string DetermineWinnerByCount()
        {
            var counts = PlayerHands.CardCounts;
            var max = counts.Max(c => c.Value);
            var leaders = counts.Where(c => c.Value == max).ToList();

            if (leaders.Count > 1)
            {
                return $"Round limit reached... it's a draw.";
            }
            return $"Round limit reached... {leaders[0].Key} wins via the card count!";
        }
    }
}
