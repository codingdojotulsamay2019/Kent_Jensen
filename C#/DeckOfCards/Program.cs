using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            Deck deck = new Deck();
            deck.Shuffle();
            Player Kent = new Player(){Name = "Kent"};
            for(int i = 0; i <5; i++)
            {
                Kent.Draw(deck);
            }
            Card GivenAway1 = Kent.Discard(2);
        }

            // To Do
            // Create a class called "Card"
            // Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a string.
            // Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds).
            // Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers.
            
            public class Card
            {
                public string StringVal {get;set;}
                public string Suit {get;set;}
                public int val {get;set;}
            }
            public class Deck
            {
                public List<Card> Cards {get;set;} = new List<Card>();

                public Deck()
                {
                    Reset();
                }
                public Card Deal()
                {
                    Card RCard = Cards[0];
                    Cards.RemoveAt(0);
                    return RCard;
                }
                public void Reset()
                {
                    int[] Values = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
                    string[] Suits = new string[] {"Clubs","Diamonds", "Hearts", "Spades"};
                
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
                            Card NewCard = new Card()
                            {
                                Suit = Suits[suit],
                                val = Values[value],
                                StringVal = $"{card} of {Suits[suit]}"
                            };
                            Cards.Add(NewCard);
                        }
                    }
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
            }
            class Player
            {
                public string Name {get;set;}
                public List<Card> Hand {get;set;} = new List<Card>();

                public Card Draw(Deck Deck)
                {
                    Card NewCard = Deck.Deal();
                    Hand.Add(NewCard);
                    return NewCard;
                }

                public Card Discard(int Index)
                {
                    try
                    {
                        Card RCard = Hand[Index];
                        Hand.RemoveAt(Index);
                        return RCard;
                    }
                    catch (System.Exception)
                    {
                        return null;
                    }
                }
            }
    }
}