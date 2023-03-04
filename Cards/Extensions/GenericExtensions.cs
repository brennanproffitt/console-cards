using System.Collections.Generic;
using System.Linq;

namespace Cards.Extensions;

public static class GenericExtensions
{
  public static IEnumerable<T> Excluding<T>(this IEnumerable<T> source, params T[] toExclude)
  {
    return source.Where(s => !toExclude.Contains(s));
  }
}