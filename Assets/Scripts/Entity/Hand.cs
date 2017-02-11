using System.Collections.Generic;

namespace Entity {
    public class Hand {
        public const int Size = 13;
        private readonly List<Card> _cards;

        public Hand(Deck deck) {
            _cards = new List<Card>(Size);
            for (var i = 0; i < Size; i++) {
                Add(deck.Draw());
            }
        }

        public void Replace(int position, Card card) {
            _cards.RemoveAt(position);
            Add(card);
        }

        public List<Card> GetCards() {
            return _cards;
        }

        private void Add(Card card) {
            _cards.Add(card);
        }
    }
}
