using Belot.Interfaces;
using System;

namespace Belot
{
    public class ComputerPlayer : Player
    {
        private IComputerTrumpStrategy _trumpStrategy;

        public ComputerPlayer(IComputerTrumpStrategy trumpStrategy)
            :base("Computer")
        {
            this._trumpStrategy = trumpStrategy;
        }

        public override Trump RiseTrump(Trump currentTrump)
        {
            return this._trumpStrategy.RiseTrump(this.Cards, currentTrump);
        }
    }
}
