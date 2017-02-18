using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Deck {
        private int _head;
        private List<Tile> _cards;

        private void InitializeCards() {
            _cards = new List<Tile>(Constants.DeckSize);
            for (var serial = 0; serial < Constants.DeckSize; serial++) {
                _cards.Add(new Tile(serial));
            }
            var random = new Random();
            for (var i = 0; i < Constants.DeckSize; i++) {
                var j = random.Next(Constants.DeckSize);
                var tmp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = tmp;
            }
        }

        public Deck() {
            _head = 0;
            InitializeCards();
        }

        public int GetSize() {
            return _cards.Count() - _head;
        }

        public Tile Draw() {
            return _cards[_head++];
        }

        public override string ToString() {
            return string.Join(" ", _cards.Select(x => string.Format("[{0} {1}]", x.Serial, x.ToString())).ToArray());
        }
    }
}
