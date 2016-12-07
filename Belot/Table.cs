using Belot.Helpers;
using System.Linq;

namespace Belot
{
    public class Table
    {
        private byte _currentPlayerIndex;
        
        public Deck Deck { get; private set; }
        public Player[] Players
        {
            get
            {
                return this.Team1.Players
                    .Concat(Team2.Players)
                    .ToArray();
            }
        }
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }
        public Trump Trump { get; private set; }
        public Player CurrentPlayer
        {
            get
            {
                return this.Players[_currentPlayerIndex];
            }
        }

        public Table(Deck deck, Team team1, Team team2)
        {
            this.Deck = deck;
            this.Team1 = team1;
            this.Team2 = team2;
            this._currentPlayerIndex = 1;
            this.Trump = null;

            SetInitialDeal();
        }
        
        public void SetSecondaryDeal()
        {
            for (int i = 0; i < this.Players.Length; i++)
            {
                var threeCards = this.Deck.PullCards(3);
                this.Players[i].Cards.AddRange(threeCards);
            }
        }
        public void StartGame()
        {
            PushPlayersToRiseTrump();
        }
        
        private void SetInitialDeal()
        {
            for (int i = 0; i < this.Players.Length; i++)
            {
                var threeCards = this.Deck.PullCards(3);
                this.Players[i].Cards.AddRange(threeCards);
            }

            for (int i = 0; i < this.Players.Length; i++)
            {
                var twoCards = this.Deck.PullCards(2);
                this.Players[i].Cards.AddRange(twoCards);
            }
        }
        private void PushPlayersToRiseTrump()
        {
            foreach (var player in this.Players)
            {
                Trump rised = player.RiseTrump(this.Trump);

                if (rised != null)
                {
                    if (this.Trump != null)
                    {
                        if (rised > this.Trump)
                        {
                            this.Trump = rised;
                        }
                    }
                    else
                    {
                        this.Trump = rised;
                    }
                }
            }

            if (this.Trump == null)
            {
                // TODO: Shuffle again and deal again (e.g new game)
            }
        }
    }
}