using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cards
{
    public class Player : IPlayer
    {
        private readonly List<Card> _cards = new();

        public ReadOnlyCollection<Card> Cards => _cards.AsReadOnly();


        public void ReceiveCard(Card card)
        {
            _cards.Add(card);
        }


        public void ClearCards()
        {
            _cards.Clear();
        }
    }
}
