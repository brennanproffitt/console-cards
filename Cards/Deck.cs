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

            Console.WriteLine(cards.Count());
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
                cards[totalCardsToShuffle] = cardInNewPosition;
            }

            _cards = new Stack<Card>(cards);
        }


        public Card Draw()
        {
            return _cards.Pop();
        }
    }
}
