using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class CardCollection
    {
        private List<Card> _cards = new List<Card>();

        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        public int TotalValue
        {
            get => GetTotalCardCollectionValue();
        }

        public int GetTotalCardCollectionValue()
        {
            int total = 0;

            foreach (var card in Cards)
            {
                total += card.PointValue;
            }

            return total;
        }
    }
}
