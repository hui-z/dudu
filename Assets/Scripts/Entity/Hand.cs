using System.Collections.Generic;
using UnityEngine;

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
            var replaced = false;
            for (var i = _cards.Count - 1; i > 0; i--) {
                if (_cards[i].Serial == serial) {
                    _cards.RemoveAt(i);
                    Add(card);
                    replaced = true;
                }
            }
            if (!replaced) {
                Debug.Log("not replaced " + serial);
            }
        }

        public List<Card> GetCards() {
            return _cards;
        }

        private void Add(Card card) {
            _cards.Add(card);
            _cards.Sort((card1, card2) => card1.Serial - card2.Serial);
        }
    }
}
