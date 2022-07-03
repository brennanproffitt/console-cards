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

            if(cardToDeal.FaceValue == FaceValue.Ace || collection.Cards.Any(p=>p.FaceValue == FaceValue.Ace))
            {
                if(collection.TotalValue  >= 12)
                {
                    cardToDeal.PointValue = 1;
                }
                else
                {
                    cardToDeal.PointValue = 11;
                }
            }

            collection.Cards.Add(cardToDeal);
            return cardToDeal;
        }
    }
}
