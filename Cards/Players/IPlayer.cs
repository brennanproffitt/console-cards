using System.Collections.ObjectModel;

namespace Cards
{
  public interface IPlayer
  {

    ReadOnlyCollection<Card> Cards {get;}

    void ReceiveCard(Card card);
    void ClearCards();
  }
}