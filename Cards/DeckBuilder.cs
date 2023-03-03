using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards;

public class DeckBuilder
{

  private HashSet<Suit> excludedSuits = null;
  private HashSet<FaceValue> excludedFaceValues = null;


  public DeckBuilder Without(params Suit[] suits)
  {
    if (suits is null) throw new ArgumentNullException(nameof(suits));
    if (suits.Length == 0) throw new ArgumentException($"'{nameof(suits)}' must have one or more items.", nameof(suits));
    if (excludedSuits is not null) throw new InvalidOperationException($"'{nameof(DeckBuilder.Without)}' should only be called a max of 1 time for suits.");

    excludedSuits = new(suits);
    return this;
  }


  public DeckBuilder Without(params FaceValue[] faceValues)
  {
    if (faceValues is null) throw new ArgumentNullException(nameof(faceValues));
    if (faceValues.Length == 0) throw new ArgumentException($"'{nameof(faceValues)}' must have one or more items.", nameof(faceValues));
    if (excludedFaceValues is not null) throw new InvalidOperationException($"'{nameof(DeckBuilder.Without)}' should only be called a max of 1 time for suits.");

    excludedFaceValues = new(faceValues);
    return this;
  }


  public Deck Create(int numberToCreate = 1)
  {
    if (numberToCreate <= 0) throw new ArgumentException("Cannot create less than 1 deck.", nameof(numberToCreate));

    var suits = Enum.GetValues<Suit>().Where(suit => !excludedSuits.Contains(suit));
    var faceValues = Enum.GetValues<FaceValue>().Where(faceValue => !excludedFaceValues.Contains(faceValue));

    var cards = new List<Card>();

    for (int i = 0; i < numberToCreate; i++)
    {
      foreach (var suit in suits)
      {
        foreach (var faceValue in faceValues)
        {
          if (Card.TryCreate(faceValue, suit, out Card card))
          {
            cards.Add(card);
          }
        }
      }
    }

    Console.WriteLine(cards.Count);
    return new Deck(cards);
  }
}