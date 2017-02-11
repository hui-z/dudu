using System.Collections.Generic;

namespace Entity {
    public class Hand {
        private readonly List<Card> _cards;

        public Hand() {
            _cards = new List<Card>(13);
        }

        public void Add(Card card) {
            _cards.Add(card);
        }

        public void Replace(int position, Card card) {
            _cards.RemoveAt(position);
            Add(card);
        }

        public List<Card> GetCards() {
            return _cards;
        }
    }
}
