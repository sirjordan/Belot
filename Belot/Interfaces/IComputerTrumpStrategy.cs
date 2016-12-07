using System.Collections.Generic;

namespace Belot.Interfaces
{
    public interface IComputerTrumpStrategy
    {
        Trump RiseTrump(IEnumerable<Card> availableCards, Trump currentTrump);
    }
}
