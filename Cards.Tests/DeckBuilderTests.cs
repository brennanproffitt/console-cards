using Cards.Extensions;
using FluentAssertions;

namespace Cards.Tests;

public class DeckBuilderTests
{

  [Fact]
  public void CreateStandardDeck()
  {
    var deck = DeckBuilder.FromStandardDeck().Create();

    deck.Cards.Should().HaveCount(52);
    deck.Cards.Exclusively(FaceValue.Ace).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Two).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Three).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Four).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Five).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Six).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Seven).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Eight).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Nine).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Ten).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Jack).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Queen).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.King).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Joker).Should().HaveCount(0);
  }


  [Fact]
  public void CreateBlackJackDeck()
  {
    var deck = DeckBuilder.FromStandardDeck().Create(6);

    deck.Cards.Should().HaveCount(312); // Casino standard
    deck.Cards.Exclusively(FaceValue.Ace).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Two).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Three).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Four).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Five).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Six).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Seven).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Eight).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Nine).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Ten).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Jack).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Queen).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.King).Should().HaveCount(24);
    deck.Cards.Exclusively(FaceValue.Joker).Should().HaveCount(0);
  }


  [Fact]
  public void CreateStandardDeckWithTwoJokers()
  {
    var deck = DeckBuilder.FromStandardDeck().WithJokers(2).Create();

    deck.Cards.Should().HaveCount(54);
    deck.Cards.Exclusively(FaceValue.Ace).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Two).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Three).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Four).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Five).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Six).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Seven).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Eight).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Nine).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Ten).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Jack).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Queen).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.King).Should().HaveCount(4);
    deck.Cards.Exclusively(FaceValue.Joker).Should().HaveCount(2);
  }


  [Fact]
  public void CreateOnlyClubsAndSpadesDeck()
  {
    var deck = new DeckBuilder().WithSuits(Suit.Clubs, Suit.Spades).Create();

    deck.Cards.Should().HaveCount(26);
    deck.Cards.Exclusively(Suit.Clubs).Should().HaveCount(13);
    deck.Cards.Exclusively(Suit.Spades).Should().HaveCount(13);
    deck.Cards.Exclusively(Suit.Diamonds).Should().HaveCount(0);
    deck.Cards.Exclusively(Suit.Hearts).Should().HaveCount(0);
    deck.Cards.Exclusively(Suit.Wild).Should().HaveCount(0);
  }
}