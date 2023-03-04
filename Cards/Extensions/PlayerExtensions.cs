using System;

namespace Cards.Extensions;

public static class PlayerExtensions
{
  public static bool HasAce(this IPlayer player)
  {
    if (player is null) throw new ArgumentNullException(nameof(player));

    return player.Cards.HasAce();
  }


  public static int NumberOfAces(this IPlayer player)
  {
    if (player is null) throw new ArgumentNullException(nameof(player));

    return player.Cards.NumberOfAces();
  }
}