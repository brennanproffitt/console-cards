using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Deck
    {
        private readonly Random RNG = new();
        private Stack<Card> _cards;


        public Deck(IEnumerable<Card> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            if (!cards.Any()) throw new ArgumentException("Cards must have at least 1 card", nameof(cards));

            _cards = new Stack<Card>(cards);
        }



        public static Deck Without(params FaceValue[] values)
        {
            if (values is null) throw new ArgumentNullException(nameof(values));
            if (values.Length == 0) throw new ArgumentException($"'{nameof(values)}' must have one or more items.", nameof(values));


            var suits = Enum.GetValues<Suit>();
            var faceValues = Enum.GetValues<FaceValue>().Where(faceValue => !values.Contains(faceValue));

            var cards = suits.SelectMany(suit => faceValues.Select(faceValue => new Card(faceValue, suit)));

            return new Deck(cards);
        }


        public override string ToString()
        {
            return string.Join(Environment.NewLine, _cards);
        }


        public void Shuffle()
        {
            int totalCardsToShuffle = _cards.Count;

            var cards = _cards.ToList();

            while (totalCardsToShuffle > 1)
            {
                totalCardsToShuffle--;
                int newPosition = RNG.Next(totalCardsToShuffle + 1);

                Card value = cards[newPosition];
                cards[newPosition] = cards[totalCardsToShuffle];
                cards[totalCardsToShuffle] = value;
            }

            _cards = new Stack<Card>(cards);
        }


        public Card Draw()
        {
            return _cards.Pop();
        }
    }
}
