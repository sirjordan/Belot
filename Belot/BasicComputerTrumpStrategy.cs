using Belot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Belot
{
    public class BasicComputerTrumpStrategy : IComputerTrumpStrategy
    {
        protected readonly int percentForRiseTrump = 12;

        public virtual Trump RiseTrump(IEnumerable<Card> availableCards, Trump currentTrump)
        {
            var trumpsAbovePercentForRise = new Dictionary<Trump, int>(); 

            foreach (Trump possible in Trumps.All)
            {
                int scoreSum = 0;
                foreach (var card in availableCards)
                {
                    int scoreForTrump = card.GetCardScorePoints(possible);
                    scoreSum += scoreForTrump;
                }

                int scorePercentOfTrumpMax = (int)Math.Floor((scoreSum / (double)possible.MaxScore) * 100);
                if (scorePercentOfTrumpMax >= percentForRiseTrump)
                {
                    trumpsAbovePercentForRise.Add(possible, scorePercentOfTrumpMax);
                }
            }

            if (trumpsAbovePercentForRise.Count > 0)
            {
                // Highest percent trump from this cards
                Trump rised = trumpsAbovePercentForRise
                    .OrderByDescending(x => x.Value)
                    .First()
                    .Key;

                if (rised > currentTrump)
                {
                    return rised;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                // Too weak cards to rize trump
                // Return pass
                return null;
            }
        }
    }
}
