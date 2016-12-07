using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Belot;

namespace Belot.Tests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Card_GetCardScorePoints_CorrectValues()
        {
            // Arrange
            Card aceOfClubs = new Card(CardColor.Clubs, new CardNumber(1));
            Card sevenOfClubs = new Card(CardColor.Clubs, new CardNumber(7));
            Card jackOfClubs = new Card(CardColor.Clubs, new CardNumber(11));
            Card nineOfClubs = new Card(CardColor.Clubs, new CardNumber(9));
            
            // Act
            int aceOfClubsAllTrumpScore = aceOfClubs.GetCardScorePoints(Trump.AllTrump);
            int sevenOfClubsAllTrumpScore = sevenOfClubs.GetCardScorePoints(Trump.AllTrump);
            int jackOfClubsAllTrumpScore = jackOfClubs.GetCardScorePoints(Trump.AllTrump);
            int jackOfClubsDaimondsTrumpScore = jackOfClubs.GetCardScorePoints(Trump.Diamonds);
            int nineOfClubsAllTrumpScore = nineOfClubs.GetCardScorePoints(Trump.AllTrump);
            int nineOfClubsDaimondsTrumpScore = nineOfClubs.GetCardScorePoints(Trump.Diamonds);
            int jackOfClubsNoTrumpScore = jackOfClubs.GetCardScorePoints(Trump.NoTrump);

            // Assert
            Assert.AreEqual(11, aceOfClubsAllTrumpScore);
            Assert.AreEqual(0, sevenOfClubsAllTrumpScore);
            Assert.AreEqual(20, jackOfClubsAllTrumpScore);
            Assert.AreEqual(2, jackOfClubsDaimondsTrumpScore);
            Assert.AreEqual(14, nineOfClubsAllTrumpScore);
            Assert.AreEqual(0, nineOfClubsDaimondsTrumpScore);
            Assert.AreEqual(4, jackOfClubsNoTrumpScore);
        }
    }
}
