using System.Collections.Generic;

namespace Belot
{
    public class Team
    {
        private Player _player1;
        private Player _player2;

        public Player[] Players
        {
            get
            {
                return new[] { _player1, _player2 };
            }
        }
        public ICollection<Card> WonCards { get; set; }

        public Team(Player player1, Player player2)
        {
            this._player1 = player1;
            this._player2 = player2;

            this._player1.TeamMate = this._player2;
            this._player2.TeamMate = this._player1;
        }
    }
}