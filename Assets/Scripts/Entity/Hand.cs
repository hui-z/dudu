using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Hand {
        private readonly List<Card> _cards;

        public Hand(Deck deck) {
            _cards = new List<Card>(Constants.HandSize);
            for (var i = 0; i < Constants.HandSize; i++) {
                Add(deck.Draw());
            }
        }

        public void Replace(int serial, Card card) {
            _cards.RemoveAll(c => c.GetSerial() == serial);
            Add(card);
        }

        public List<Card> GetCards() {
            return _cards;
        }

        private void Add(Card card) {
            _cards.Add(card);
            _cards.Sort((card1, card2) => card1.GetSerial() - card2.GetSerial());
        }
    }
}
