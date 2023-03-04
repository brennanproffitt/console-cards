using System;
using System.Linq;

namespace Cards.Extensions;

public static class DeckBuilderExtensions
{
  public static DeckBuilder WithJokers(this DeckBuilder deckBuilder, int numberOfJokers)
  {
    deckBuilder.With(numberOfJokers, FaceValue.Joker, Suit.Wild);
    return deckBuilder;
  }


  public static DeckBuilder WithSuits(this DeckBuilder deckBuilder, params Suit[] suits)
  {
    var faceValues = Enum.GetValues<FaceValue>().Excluding(FaceValue.Joker).ToHashSet();

    deckBuilder.With(faceValues, suits.ToHashSet());
    return deckBuilder;
  }
}