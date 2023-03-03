using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
  // TODO: Fix jokers
  public class Card
  {
    public FaceValue FaceValue { get; }
    public Suit Suit { get; }



    public Card(FaceValue faceValue, Suit suit)
    {
      if (suit == Suit.Wild && faceValue != FaceValue.Joker) throw new InvalidOperationException("Attempted to create a non-joker wild");
      if (suit != Suit.Wild && faceValue == FaceValue.Joker) throw new InvalidOperationException("Attempted to create a suited joker");

      FaceValue = faceValue;
      Suit = suit;
    }

    public static bool TryCreate(FaceValue faceValue, Suit suit, out Card card)
    {
      if ((suit == Suit.Wild && faceValue != FaceValue.Joker) || (suit != Suit.Wild && faceValue == FaceValue.Joker))
      {
        card = null;
        return false;
      }

      card = new(faceValue, suit);
      return true;
    }


    public void Deconstruct(out FaceValue faceValue, out Suit suit)
    {
        faceValue = FaceValue;
        suit = Suit;
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
        FaceValue.Joker => "Joker",
        _ => throw new NotImplementedException()
      };

      var symbol = Suit switch
      {
        Suit.Clubs => "♣",
        Suit.Diamonds => "♦",
        Suit.Hearts => "♥",
        Suit.Spades => "♠",
        _ => throw new NotImplementedException()
      };


      Console.OutputEncoding = Encoding.UTF8;
      Console.Write($"{faceValue}{symbol}");

      Console.ResetColor();
    }
  }
}
