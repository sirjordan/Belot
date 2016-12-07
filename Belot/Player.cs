using System.Collections.Generic;

namespace Belot
{
    public abstract class Player
    {
        public string Name { get; protected set; }
        public ISet<Card> Cards { get; set; }
        
        public Player(string name)
        {
            this.Name = name ?? "Unnamed player";
            this.Cards = new HashSet<Card>();
        }

        public abstract Trump RiseTrump(Trump currentTrump);
    }
}