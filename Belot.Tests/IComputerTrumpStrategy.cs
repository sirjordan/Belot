using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Belot.Interfaces;

namespace Belot.Tests
{
    [TestClass]
    public class IComputerTrumpStrategyTest
    {
        [TestMethod]
        public void BasicComputerTrumpStrategy_RisesCorrectTrumps_Color()
        {
            // Arrange
            IComputerTrumpStrategy strategy = new BasicComputerTrumpStrategy();
            var cards = new Card[]
            {
                new Card(CardColor.Clubs, CardNumber.Jack),
                new Card(CardColor.Clubs, new CardNumber(9)),
                new Card(CardColor.Clubs, CardNumber.King),
                new Card(CardColor.Hearts, new CardNumber(7)),
                new Card(CardColor.Hearts, new CardNumber(8)),
            };

            // Act
            Trump rised = strategy.RiseTrump(cards, Trump.Clubs);

            // Assert
            Assert.IsTrue(Trump.Clubs == rised);
        }

        [TestMethod]
        public void BasicComputerTrumpStrategy_Not_RisesClubsTrump_Color()
        {
            // Arrange
            IComputerTrumpStrategy strategy = new BasicComputerTrumpStrategy();
            var cards = new Card[]
            {
                new Card(CardColor.Clubs, CardNumber.King),
                new Card(CardColor.Diamonds, new CardNumber(8)),
                new Card(CardColor.Clubs, CardNumber.Ace),
                new Card(CardColor.Hearts, new CardNumber(7)),
                new Card(CardColor.Hearts, new CardNumber(8)),
            };

            // Act
            Trump rised = strategy.RiseTrump(cards, Trump.Clubs);

            // Assert
            Assert.IsTrue(Trump.Clubs != rised);
        }
    }
}
