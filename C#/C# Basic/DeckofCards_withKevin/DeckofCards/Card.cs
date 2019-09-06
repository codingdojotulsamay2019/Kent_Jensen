using System;

namespace DeckOCards
{
    class Card
    {
        public int Val;
        public string Suit;
        // StringVal example: Ace of Spades, King of Hearts, etc;
        // string[] Suits;
        public string StringVal;
        public Card(int value, string suit)
        {
            // this is the card constructor

            // generate StringVal
            string card;
            switch (value)
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
                        card = value.ToString();
                        break;
                    }
                }
                this.StringVal = $"{card} of {suit}";
        }  
        
    }
}
