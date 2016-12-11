using Belot.Interfaces;
using System;
using System.Linq;

namespace Belot.Clients
{
    public class ConsoleClient : IClient
    {
        private ConsoleColor normalColor = ConsoleColor.Yellow;
        private ConsoleColor importantColor = ConsoleColor.Green;
        private HumanPlayer player;
        private Table table;

        public Deck Deck { get; protected set; }

        public ConsoleClient(Deck deck)
        {
            this.Deck = deck;
        }
        
        public void BeginGame()
        {
            WriteNormal("Enter player name: ");
            string playerName = Console.ReadLine();
            this.player = new HumanPlayer(playerName ?? "Player");

            IComputerTrumpStrategy strategy = new BasicComputerTrumpStrategy();
            var team1 = new Team(player, new ComputerPlayer(strategy));
            var team2 = new Team(new ComputerPlayer(strategy),  new ComputerPlayer(strategy));

            this.player.ShouldRiseTrump += Player_ShouldRiseTrump;

            var table = new Table(this.Deck, team1, team2);
            this.table = table;

            table.PlayerRisedTrump += Table_PlayerRisedTrump;

            table.StartGame();
        }
        
        private Trump Player_ShouldRiseTrump()
        {
            WriteNormal("---------------------");
            WriteNormal("You have the following cards: ");
            WriteImportant(string.Join("\n\r", this.player.Cards.Select(x => x.ToString())));
            WriteNormal("---------------------");
            
            WriteNormal("Please rize trump:");
            Trump rised = ShowRiseTrump();

            return rised;
        }
        private void Table_PlayerRisedTrump(Player arg1, Trump arg2)
        {
            WriteNormal(string.Format("{0} rised {1}", arg1.Name, arg2.Name));
        }
        private Trump ShowRiseTrump()
        {
            WriteSelection(Trumps.All.First().Name);
            foreach (var possible in Trumps.All.Skip(1))
            {
                WriteImportant(possible.Name);
            }

            Console.ReadLine();

            return Trump.Clubs;
        }
        private void WriteNormal(string text)
        {
            Console.ForegroundColor = this.normalColor;
            Console.WriteLine(text);
        }
        private void WriteImportant(string text)
        {
            Console.ForegroundColor = this.importantColor;
            Console.WriteLine(text);
        }
        private void WriteSelection(string text)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
