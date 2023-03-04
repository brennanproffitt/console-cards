using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Extensions;

namespace Cards;

public class DeckBuilder
{
  private List<Func<IEnumerable<Card>>> factories = new();


  public static DeckBuilder FromBuilder(DeckBuilder deckBuilder)
  {
    return new DeckBuilder()
    {
      factories = deckBuilder.factories
    };
  }


  public static DeckBuilder FromStandardDeck()
  {
    var suits = Enum.GetValues<Suit>().Excluding(Suit.Wild).ToHashSet();
    var faceValues = Enum.GetValues<FaceValue>().Excluding(FaceValue.Joker).ToHashSet();

    return new DeckBuilder().With(faceValues, suits);
  }


  public DeckBuilder With(int numberToCreate, FaceValue faceValue, Suit suit)
  {
    if (numberToCreate < 1) throw new ArgumentException("Value must be greater than 0");

    var factory = CreateCardFactory(numberToCreate, faceValue, suit);
    factories.Add(factory);

    return this;
  }


  public DeckBuilder With(FaceValue faceValue, params Suit[] suits)
  {
    if (suits is null) throw new ArgumentNullException(nameof(suits));
    if (!suits.Any()) throw new ArgumentException("Must have 1 or more suits", nameof(suits));

    var factory = CreateCardFactory(faceValue, suits);
    factories.Add(factory);

    return this;
  }


  public DeckBuilder With(HashSet<FaceValue> faceValues, HashSet<Suit> suits)
  {
    if (faceValues is null) throw new ArgumentNullException(nameof(faceValues));
    if (!faceValues.Any()) throw new ArgumentException("Must have at least 1 face value", nameof(faceValues));

    if (suits is null) throw new ArgumentNullException(nameof(suits));
    if (!suits.Any()) throw new ArgumentException("Must have at least 1 suit", nameof(suits));

    factories.Add(CreateCardFactory(faceValues, suits));

    return this;
  }


  public DeckBuilder Reset()
  {
    factories.Clear();
    return this;
  }


  public Deck Create(int numberToCreate = 1, bool reset = true)
  {
    List<Card> cards = new();

    for (int i = 0; i < numberToCreate; i++)
    {
      foreach (var factory in factories)
      {
        cards.AddRange(factory());
      }
    }

    if (reset)
    {
      Reset();
    }

    return new Deck(cards);
  }



  private Func<IEnumerable<Card>> CreateCardFactory(int numberToCreate, FaceValue faceValue, Suit suit)
  {
    return () =>
    {
      List<Card> cards = new();
      for (int i = 0; i < numberToCreate; i++)
      {
        cards.Add(new Card(faceValue, suit));
      }
      return cards;
    };
  }


  private Func<IEnumerable<Card>> CreateCardFactory(HashSet<FaceValue> faceValues, HashSet<Suit> suits)
  {
    return () => suits.SelectMany(suit => faceValues.Select(faceValue => new Card(faceValue, suit)));
  }


  private Func<IEnumerable<Card>> CreateCardFactory(FaceValue faceValue, params Suit[] suits)
  {
    return () => suits.Select(suit => new Card(faceValue, suit));
  }
}