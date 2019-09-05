using System;
using System.Collections.Generic;

namespace DeckOCards
{
    class Deck
    {
        // A deck should consist of 52 cards and have the following methods
        // array list of card objects
        public List<Card> Cards {get;set;} = new List<Card>();
        public Deck()
        {
            Shuffle();
        }
        public Card Deal()
        {
            Cards.RemoveAt(0);
            return Cards[0];
        }
        public void Shuffle()
        {
            Random Rand = new Random();
            for(int i = 0; i < Cards.Count; i++)
            {
                int SwapIdx = Rand.Next(0,Cards.Count);
                Card Swap = Cards[0];
                Cards[0] = Cards[SwapIdx];
                Cards[SwapIdx] = Swap;
            }
        }
        public void Reset()
        {
        int[] Values = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
        string[] Suits = new string[] {"Clubs", "Diamonds", "Spades", "Hearts"};
        
            for(int value = 0; value < Values.Length; value++)
            {
                for(int suit = 0; suit < Suits.Length; suit++)
                {
                    string card;
                    switch(Values[value])
                    {
                        case 1:
                        {
                            card = "Ace";
                            break;
                        }
                        case 11: 
                        {
                            card = "Jack";
                            break;
                        }
                        case 12:
                        {
                            card = "Queen";
                            break;
                        }
                        case 13:
                        {
                            card = "King";
                            break;
                        }
                        default:
                        {
                            card = Values[value].ToString();
                            break;
                        }
                    }
                    Card NewCard = new Card(suit,value.ToString())
                    {
                        Suit = Suits[suit],
                        Val = Values[value],
                        StringVal = $"{card} of {Suits[suit]}"
                    };
                    Cards.Add(NewCard);
                }
            }
        }
    }
}
