
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.Extensions;

public static class CardExtensions
{
  public static bool HasAce(this IEnumerable<Card> cards)
  {
    return cards.Any(card => card.FaceValue == FaceValue.Ace);
  }


  public static int NumberOfAces(this IEnumerable<Card> cards)
  {
    return cards.Count(card => card.FaceValue == FaceValue.Ace);
  }


  public static IEnumerable<Card> Excluding(this IEnumerable<Card> cards, FaceValue faceValue)
  {
    return cards.Where(card => card.FaceValue != faceValue);
  }


  public static IEnumerable<Card> Excluding(this IEnumerable<Card> cards, Suit suit)
  {
    return cards.Where(card => card.Suit != suit);
  }


  /// <summary>
  /// Returns cards whose <see cref="P:Cards.Card.FaceValue"/> is equal to <paramref name="faceValue"/>
  /// </summary>
  /// <param name="cards">Cards to filter</param>
  /// <param name="faceValue">The face value to filter by</param>
  /// <returns></returns>
  public static IEnumerable<Card> Exclusively(this IEnumerable<Card> cards, FaceValue faceValue)
  {
    return cards.Where(card => card.FaceValue == faceValue);
  }


  /// <summary>
  /// Returns cards whose <see cref="P:Cards.Card.Suit"/> is equal to <paramref name="suit"/>
  /// </summary>
  /// <param name="cards">Cards to filter</param>
  /// <param name="suit">The suit to filter by</param>
  /// <returns></returns>
  public static IEnumerable<Card> Exclusively(this IEnumerable<Card> cards, Suit suit)
  {
    return cards.Where(card => card.Suit == suit);
  }


  public static void FancyDisplay(this Card card)
  {
    Console.BackgroundColor = ConsoleColor.White;

    Console.ForegroundColor = card.Suit switch
    {
      Suit.Hearts or Suit.Diamonds => ConsoleColor.Red,
      Suit.Clubs or Suit.Spades => ConsoleColor.Black,
    };

    var faceValue = card.FaceValue switch
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

    var symbol = card.Suit switch
    {
      Suit.Clubs => "♣",
      Suit.Diamonds => "♦",
      Suit.Hearts => "♥",
      Suit.Spades => "♠",
      Suit.Wild => throw new NotImplementedException() // Extra wild
    };


    Console.OutputEncoding = Encoding.UTF8;
    Console.Write($"{faceValue}{symbol}");

    Console.ResetColor();
  }
}