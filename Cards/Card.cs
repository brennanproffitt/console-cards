using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Card
    {
        public FaceValue FaceValue{ get; set; }
        public Suit Suit { get; set; }
        public int PointValue { get; set; }

        public Card(FaceValue faceValue, Suit suit)
        {
            FaceValue = faceValue;
            Suit = suit;
        }

        public Card(FaceValue faceValue, Suit suit, int pointValue)
        {
            FaceValue = faceValue;
            Suit = suit;
            PointValue = pointValue;
        }

        public override string ToString()
        {
            return $"{FaceValue} of {Suit} (worth {PointValue} points)";
        }
    }

    public enum FaceValue
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        J,
        Q,
        K
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
