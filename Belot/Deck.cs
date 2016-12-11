using System;
using System.Collections.Generic;
using System.Linq;

namespace Belot
{
    public class Deck
    {
        public ISet<Card> Cards { get; private set; }

        public Deck()
        {
            this.Cards = new HashSet<Card>();
            GenerateDeck();
        }

        public void Shuffle()
        {
            this.Cards = new HashSet<Card>(this.Cards
                .OrderBy(c => Guid.NewGuid())
                .ToList());
        }
        public Card PullCard()
        {
            if (this.Cards.Count > 0)
            {
                var topCard = this.Cards.First();
                this.Cards.Remove(topCard);

                return topCard;
            }
            else
            {
                throw new InvalidOperationException("Cards is empty! Cant pull cards from an empty deck.");
            }
        }
        public IEnumerable<Card> PullCards(byte count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return PullCard();
            }
        }

        private void GenerateDeck()
        {
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                for (byte i = 1; i <= CardNumber.MaxCardNumber; i++)
                {
                    if (!CardNumber.SkippedCardNumbers.Contains(i))
                    {
                        var cardNumber = new CardNumber(i);
                        var card = new Card(color, cardNumber);
                        this.Cards.Add(card);
                    }
                }
            }
        }
    }
}