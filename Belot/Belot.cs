using Belot.Clients;
using System;

namespace Belot
{
    class Belot
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();

            var client = new ConsoleClient(deck);
            client.BeginGame();
        }
        
    }
}
