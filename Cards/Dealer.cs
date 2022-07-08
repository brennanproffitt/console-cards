using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Dealer
    {
        private Deck _deck = new Deck();
        public Deck Deck
        {
            get => _deck;
            set => _deck = value;
            
        }

        public void Shuffle()
        {
            Deck.Shuffle();
        }

        public Card DealOneCard(CardCollection collection)
        {
            var cardToDeal = _deck.Cards.First();

            _deck.Cards.Remove(cardToDeal);
            collection.Cards.Add(cardToDeal);

            if (collection.Cards.Any(p => p.FaceValue == FaceValue.Ace))
            {
                OptimizeAceValues(collection);
            }

            return cardToDeal;
        }

        private void OptimizeAceValues(CardCollection collection)
        {
            IEnumerable<Card> aces = collection.Cards.Where(c => c.FaceValue == FaceValue.Ace);

            if(collection.TotalValue >= 12 && collection.TotalValue < 21)
            {
                foreach (Card ace in aces)
                {
                    ace.PointValue = 1;
                }
            }
            else if(aces.Count() == 1 && collection.TotalValue <= 11)
            {
                aces.FirstOrDefault().PointValue = 11;
            }
            else
            {
                foreach (Card ace in aces)
                {
                    ace.PointValue = 11;
                }
            }
        }
    }
}
