using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Card
    {
        public FaceValue FaceValue { get; }
        public Suit Suit { get; }


        public Card(FaceValue faceValue, Suit suit)
        {
            FaceValue = faceValue;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{FaceValue} of {Suit}";
        }

        public void FancyDisplay()
        {
            Console.BackgroundColor = ConsoleColor.White;

            Console.ForegroundColor = Suit switch
            {
                Suit.Hearts or Suit.Diamonds => ConsoleColor.Red,
                Suit.Clubs or Suit.Spades => ConsoleColor.Black,
            };

            var faceValue = FaceValue switch
            {
                FaceValue.Ace => "A",
                FaceValue.Two => "2",
                FaceValue.Three => "3",
                FaceValue.Four => "4",
                FaceValue.Five => "5",
                FaceValue.Six => "6",
                FaceValue.Seven => "7",
                FaceValue.Eight => "8",
                FaceValue.Nine => "9",
                FaceValue.Ten => "10",
                FaceValue.Jack => "J",
                FaceValue.Queen => "Q",
                FaceValue.King => "K",
                FaceValue.Joker => "Joker" // TODO: FIX
            };

            var symbol = Suit switch
            {
                Suit.Clubs => "♣",
                Suit.Diamonds => "♦",
                Suit.Hearts => "♥",
                Suit.Spades => "♠"
            };


            Console.OutputEncoding = Encoding.UTF8;
            Console.Write($"{faceValue}{symbol}");

            Console.ResetColor();
        }


        static Dictionary<(Suit, FaceValue), char> CardSymbols = new Dictionary<(Suit, FaceValue), char>()
        {
            //{(Suit.Clubs, FaceValue.Ace), '\u1F0D1' }
        };
    }
}
