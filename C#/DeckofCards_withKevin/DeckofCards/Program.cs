using System;

namespace DeckOCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck Deck = new Deck();
            Player[] Players = new Player[]
            {
                new Player("Phil"),
                new Player("Claire"),
                new Player("Ty")
            };
            // add 5 cards to each players hand
            for(int i = 0; i < Players.Length; i++)
            {
                for(int x = 0; x < 5; x++)
                {
                    Players[i].Draw(Deck);
                }
            }
            // display hand of all players
            for(int i = 0; i < Players.Length; i++)
            {
                Players[i].DisplayHand();
            }
            // discard a random index from each player hand of all players
            Random Rand = new Random();
            for(int i = 0; i < Players.Length; i++)
            {
                int Index = Rand.Next(Players[i].Hand.Count);
                Players[i].Discard(Index);
            }
            // display hand of all players
            for(int i = 0; i < Players.Length; i++)
            {
                Players[i].DisplayHand();
            }
            Console.WriteLine(Deck.Deal().StringVal);
        }
    }
}