using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();

        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        public Deck()
        {
            Initialize();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _cards);
        }

        private void Initialize()
        {
            _cards.Clear();
            int numberValue;
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                {
                    numberValue = GetCardValue(faceValue);
                    Card newCard = new Card(faceValue, suit, numberValue);
                    _cards.Add(newCard);
                }
            }
        }

        private static int GetCardValue(FaceValue faceValue)
        {
            switch (faceValue)
            {
                case FaceValue.Ace:
                    return 0;
                case FaceValue.Two:
                    return 2;
                case FaceValue.Three:
                    return  3;
                case FaceValue.Four:
                    return 4;
                case FaceValue.Five:
                    return 5;
                case FaceValue.Six:
                    return 6;
                case FaceValue.Seven:
                    return 7;
                case FaceValue.Eight:
                    return 8;
                case FaceValue.Nine:
                    return 9;
                case FaceValue.Ten:
                case FaceValue.J:
                case FaceValue.Q:
                case FaceValue.K:
                    return 10;
                default:
                    return 0;
            }
        }

        public void Shuffle()
        {
            var cards = Cards;
            var rng = new Random();

            int totalCardsToShuffle = cards.Count;
            while(totalCardsToShuffle > 1)
            {
                totalCardsToShuffle--;
                int newPosition = rng.Next(totalCardsToShuffle + 1);
                Card cardInNewPosition = cards[newPosition];
                cards[newPosition] = cards[totalCardsToShuffle];
                cards[totalCardsToShuffle] = cardInNewPosition;
            }
        }
    }
}
