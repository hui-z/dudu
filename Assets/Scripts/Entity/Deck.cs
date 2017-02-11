using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Deck {
        private int _head;
        private List<Card> _cards;

        private void InitializeCards() {
            _cards = new List<Card>(136);
            for (var suit = 1; suit <= 3; suit++) {
                for (var size = 1; size <= 9; size++) {
                    for (var seq = 1; seq <= 4; seq++) {
                        _cards.Add(new Card(suit, size, seq));
                    }
                }
            }
            for (var size = 1; size <= 7; size++) {
                for (var seq = 1; seq <= 4; seq++) {
                    _cards.Add(new Card(4, size, seq));
                }
            }
            // TODO randomize _cards
        }

        public Deck() {
            _head = 0;
            InitializeCards();
        }

        public int GetSize() {
            return _cards.Count() - _head;
        }

        public Card Draw() {
            return _cards[_head++];
        }
    }
}
