using System;

namespace Belot
{
    public class HumanPlayer : Player
    {
        public event Func<Trump> ShouldRiseTrump;

        public HumanPlayer(string name)
            :base(name)
        {
        }

        public override Trump RiseTrump(Trump currentTrump)
        {
            return this.ShouldRiseTrump();
        }
    }
}
