using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cardgame.ExtensionMethods;

namespace Cardgame.Domain
{
    public class PlayingCardDeck
    {
        public List<PlayingCard> Cards { get; } = new List<PlayingCard>();
        public PlayingCardDeck()
        {
            var ranks = Enum.GetNames(typeof(CardRank));
            var colors = Enum.GetNames(typeof(CardColor));
            /// Add playingcards to deck
            foreach (var color in colors)
            {
                foreach (var rank in ranks)
                {
                    this.Cards.Add(new PlayingCard { Color = Enum.Parse<CardColor>(color), Rank = Enum.Parse<CardRank>(rank) });
                }
            }
            
            this.Cards.Shuffle();
        }

        /// <summary>
        /// Method to get the first card in the deck.
        /// </summary>
        /// <returns>First PlayingCard in the deck.</returns>
        public PlayingCard GetFirstCard()
        {
            var firstCard = this.Cards[0];
            this.Cards.RemoveAt(0);
            return firstCard;
        }

        /// <summary>
        /// Method to put a card at the bottom of the deck.
        /// </summary>
        /// <param name="card"></param>
        public void PutCardLast(PlayingCard card)
        {
            this.Cards.Add(card);
        }

        /// <summary>
        /// Method that puts a list of cards at the bottom of the deck.
        /// </summary>
        /// <param name="cards"></param>
        public void PutCardLast(List<PlayingCard> cards)
        {
            this.Cards.AddRange(cards);
        }

        /// <summary>
        /// Method returns the amount of cards requested from the top of the deck.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>List of PlayingCard</returns>
        public List<PlayingCard> GetCardsFromTop(int count)
        {
            List<PlayingCard> cards = this.Cards.Select(x => x).Take(count).ToList();
            this.Cards.RemoveRange(0, count);
            return cards;
        }
    }
}
