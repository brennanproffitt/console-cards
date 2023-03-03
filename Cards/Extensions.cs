using System;
using System.Collections.Generic;
using System.Linq;


namespace Cards
{
  public static class Extensions
  {
    public static bool HasAce(this IPlayer player)
    {
      if(player is null) throw new ArgumentNullException(nameof(player));

      return player.Cards.HasAce();
    }


    public static int NumberOfAces(this IPlayer player)
    {
      if(player is null) throw new ArgumentNullException(nameof(player));

      return player.Cards.NumberOfAces();
    }



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
  }
}