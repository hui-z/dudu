using System.Collections.Generic;
using System.Linq;

namespace Entity {
    public class Hand {
        private readonly List<Tile> _cards;

        public Hand(Deck deck) {
            _cards = new List<Tile>(Constants.HandSize);
            for (var i = 0; i < Constants.HandSize; i++) {
                Add(deck.Draw());
            }
        }

        public void Discard(int serial) {
            Tile tileToRemove = null;
            foreach (var card in _cards) {
                if (card.Serial == serial) {
                    tileToRemove = card;
                }
            }
            if (tileToRemove != null) {
                _cards.Remove(tileToRemove);
            }
        }

        public List<Tile> GetCards() {
            return _cards;
        }

        public void Add(Tile tile) {
            _cards.Add(tile);
            _cards.Sort((card1, card2) => card1.Serial - card2.Serial);
        }

        public override string ToString() {
            return string.Join(" ", _cards.Select(x => string.Format("[{0} {1}]", x.Serial, x.ToString())).ToArray());
        }
    }
}
