using Belot.Helpers;
using System;
using System.Linq;

namespace Belot
{
    public class Table
    {
        private byte _currentPlayerIndex;
        private bool _initialDealSet;

        public event Action<Player, Trump> PlayerRisedTrump;
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
            this._currentPlayerIndex = (byte)(new Random()).Next(0, this.Players.Length);
            this.Trump = null;
            this._initialDealSet = false;
        }
        
        public void SetInitialDeal()
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

            this._initialDealSet = true;
        }
        public void StartGame()
        {
            if (this._initialDealSet)
            {
                PushPlayersToRiseTrump();
            }
            else
            {
                throw new InvalidOperationException("Game must be started after SetInitialDeal() is called.");
            }
        }
        public void SetSecondaryDeal()
        {
            for (int i = 0; i < this.Players.Length; i++)
            {
                var threeCards = this.Deck.PullCards(3);
                this.Players[i].Cards.AddRange(threeCards);
            }
        }

        private void PushPlayersToRiseTrump()
        {
            for (int i = 0; i < this.Players.Length; i++)
            {
                Trump rised = this.CurrentPlayer.RiseTrump(this.Trump);

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

                this.PlayerRisedTrump(this.CurrentPlayer, rised);
                NextPlayerTurn();
            }

            if (this.Trump == null)
            {
                // TODO: Shuffle again and deal again (e.g new game)
            }
        }
        private void NextPlayerTurn()
        {
            this._currentPlayerIndex++;
            if (this._currentPlayerIndex >= this.Players.Length)
            {
                this._currentPlayerIndex = 0;
            }
        }
    }
}