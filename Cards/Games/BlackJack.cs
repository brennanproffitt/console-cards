using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Extensions;

namespace Cards.Games
{
  internal class BlackJack : Game
  {
    const int ACE_MIN_VALUE = 1;
    const int ACE_MAX_VALUE = 11;
    const int MAX_VALID_SCORE = 21;

    private readonly Deck _deck = DeckBuilder.FromStandardDeck().Create(6);

    private List<IPlayer> Players = new()
    {
        new Dealer(),
        new Player(),
    };


    public BlackJack()
    {
      Name = "Blackjack";
    }


    public override void Play()
    {
      _deck.Shuffle();

      DealCards();

      var playerScores = GetPlayerScores();
      foreach (var playerScore in playerScores)
      {
        // TODO: implement score checking and gaining extra cards loop
      }
    }


    private void DealCards()
    {
      Players.ForEach(DealCardsToPlayer);
    }


    private void DealCardsToPlayer(IPlayer player)
    {
      DealCardToPlayer(_deck.Draw(), player);
      DealCardToPlayer(_deck.Draw(), player);
    }


    private void DealCardToPlayer(Card card, IPlayer player)
    {
      if (card is null) throw new ArgumentNullException(nameof(card));
      if (player is null) throw new ArgumentNullException(nameof(player));

      player.ReceiveCard(card);
    }


    private IEnumerable<(IPlayer player, int score)> GetPlayerScores()
    {
      return Players.Select(player => (player, GetScore(player)));
    }

    private int GetScore(IPlayer player)
    {
      var score = player.Cards.Excluding(FaceValue.Ace).Sum(GetCardValue);

      foreach (var ace in player.Cards.Exclusively(FaceValue.Ace))
      {
        score += score + ACE_MAX_VALUE <= MAX_VALID_SCORE
          ? ACE_MAX_VALUE
          : ACE_MIN_VALUE;
      }

      return score;
    }


    private int GetCardValue(Card card) => card.FaceValue switch
    {
      FaceValue.Two => 2,
      FaceValue.Three => 3,
      FaceValue.Four => 4,
      FaceValue.Five => 5,
      FaceValue.Six => 6,
      FaceValue.Seven => 7,
      FaceValue.Eight => 8,
      FaceValue.Nine => 9,
      FaceValue.Ten => 10,
      FaceValue.Jack => 10,
      FaceValue.Queen => 10,
      FaceValue.King => 10,
      _ => throw new NotImplementedException(),
    };
  }
}
