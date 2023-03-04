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
  }
}
