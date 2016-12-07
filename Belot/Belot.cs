using System;

namespace Belot
{
    class Belot
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();

            var pesho = new HumanPlayer("Pesho");
            pesho.ShouldRiseTrump += Pesho_HumanRiseTrump;
            var rised =  pesho.RiseTrump(Trump.Diamonds);

            var team1 = new Team(new HumanPlayer("Pesho"), new HumanPlayer("Gosho"));
            var team2 = new Team(new HumanPlayer("Stoian"), new HumanPlayer("Penka"));

            var table = new Table(deck, team1, team2);

            // TODO: Rise colors
            table.SetSecondaryDeal();

            foreach (var player in table.Players)
            {
                Console.WriteLine(player.Name);
                foreach (var card in player.Cards)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Cards remain: " + table.Deck.Cards.Count);
        }

        private static Trump Pesho_HumanRiseTrump()
        {
            // Enter from the console
            string entered = Console.ReadLine();
            return Trump.Diamonds;
        }
    }
}
