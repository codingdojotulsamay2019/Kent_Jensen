using System;
using System.Collections.Generic;

namespace DeckOCards
{
    class Player
    {
        public List<Card> Hand {get;set;} = new List<Card>();
        // Player class should have the following: 
        // fields
        //      hand, arrayList of cards(5)
        public string Name;
        public Player(string Name)
        {
            this.Name = Name;
        }
        public Card Discard(int Index)
        {
            try 
            {
            Card CardDiscarded = this.Hand[Index];
            this.Hand.RemoveAt(Index);
            return CardDiscarded;
            }
            catch (System.Exception)
            {
                return null;
            };
        }

        public Card Draw(Deck Deck)
        {
            Card ACard = Deck.Deal();
            Hand.Add(ACard);
            return ACard;
        }
        public void DisplayHand()
        {
            if(this.Hand == null)
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
